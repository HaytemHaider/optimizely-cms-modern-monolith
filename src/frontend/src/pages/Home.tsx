import { Link } from '@inertiajs/react'
import { PageDebugCard } from '@/components/PageDebugCard'
import { SiteHeader } from '@/components/SiteHeader'
import { CmsPageProps } from '@/types/cms-page-props'

export default function Home(props: CmsPageProps) {
  return (
    <main>
      <SiteHeader />
      <div className="mx-auto flex max-w-3xl flex-col gap-4 px-6 py-10">
        <h1 className="text-3xl font-bold">Home Page</h1>
        <p className="text-slate-700">This page is routed by Optimizely and rendered by Inertia + React.</p>
        <div>
          <Link
            className="inline-flex rounded bg-slate-900 px-4 py-2 text-sm font-medium text-white"
            href={props.links?.subPageUrl ?? '/sub-page'}>
            Go to SubPage
          </Link>
        </div>
        <PageDebugCard payload={props} />
      </div>
    </main>
  )
}
