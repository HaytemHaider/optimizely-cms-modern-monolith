export type CmsPageProps = {
  pageType: 'HomePage' | 'SubPage'
  content: unknown
  route: {
    path: string
    language?: string
  }
  links?: {
    subPageUrl?: string | null
    homeUrl?: string | null
  }
}
