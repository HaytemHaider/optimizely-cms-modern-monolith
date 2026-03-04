import { Link } from '@inertiajs/react'

export function SiteHeader() {
  return (
    <header className="border-b bg-white">
      <div className="mx-auto flex max-w-3xl items-center justify-between px-6 py-4">
        <Link href="/" className="text-sm font-semibold text-slate-900">
          Optimizely + Inertia Demo
        </Link>
        <div className="flex gap-2 text-xs">
          <span className="rounded bg-blue-100 px-2 py-1 text-blue-700">Rendered via Inertia</span>
          <span className="rounded bg-emerald-100 px-2 py-1 text-emerald-700">CDA in-process</span>
        </div>
      </div>
    </header>
  )
}
