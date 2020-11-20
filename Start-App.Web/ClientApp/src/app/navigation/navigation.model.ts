export interface NavigationNode {
    title: string;
    url?: string;
    tooltip?: string;
    hidden?: boolean;
    children?: NavigationNode[];
}

export type NavigationResponse = { __versionInfo: VersionInfo } & { [name: string]: NavigationNode[] | VersionInfo };

export interface NavigationViews {
    [name: string]: NavigationNode[];
}

export interface CurrentNode {
    url: string;
    view: string;
    nodes: NavigationNode[];
}

export interface CurrentNodes {
    [view: string]: CurrentNode;
}

export interface VersionInfo {
    raw: string;
    major: number;
    minor: number;
    patch: number;
    prerelease: string[];
    build: string;
    version: string;
    codeName: string;
    isSnapshot: boolean;
    full: string;
    branch: string;
    commitSHA: string;
}