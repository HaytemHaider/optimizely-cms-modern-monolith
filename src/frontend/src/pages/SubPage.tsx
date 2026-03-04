import { Link } from '@inertiajs/react'
import { PageDebugCard } from '@/components/PageDebugCard'
import { SiteHeader } from '@/components/SiteHeader'
import { CmsPageProps } from '@/types/cms-page-props'

export default function SubPage(props: CmsPageProps) {
  return (
    <main>
      <SiteHeader />
      <div className="mx-auto flex max-w-3xl flex-col gap-4 px-6 py-10">
        <h1 className="text-3xl font-bold">Sub Page</h1>
        <p className="text-slate-700">Client-side navigation is handled by Inertia.</p>
        <div>
          <Link className="inline-flex rounded border px-4 py-2 text-sm font-medium" href={props.links?.homeUrl ?? '/'}>
            Back to Home
          </Link>
        </div>
        <PageDebugCard payload={props} />
      </div>
    </main>
  )
}
