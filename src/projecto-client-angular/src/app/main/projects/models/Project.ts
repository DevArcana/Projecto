export default class Project {
    constructor(
        public name: string,
        public slug: string,
        public description: string | null = null
    ) { }
}