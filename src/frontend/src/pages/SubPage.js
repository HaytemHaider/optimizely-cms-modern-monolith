import { jsx as _jsx, jsxs as _jsxs } from "react/jsx-runtime";
import { Link } from '@inertiajs/react';
import { PageDebugCard } from '@/components/PageDebugCard';
import { SiteHeader } from '@/components/SiteHeader';
export default function SubPage(props) {
    return (_jsxs("main", { children: [_jsx(SiteHeader, {}), _jsxs("div", { className: "mx-auto flex max-w-3xl flex-col gap-4 px-6 py-10", children: [_jsx("h1", { className: "text-3xl font-bold", children: "Sub Page" }), _jsx("p", { className: "text-slate-700", children: "Client-side navigation is handled by Inertia." }), _jsx("div", { children: _jsx(Link, { className: "inline-flex rounded border px-4 py-2 text-sm font-medium", href: props.links?.homeUrl ?? '/', children: "Back to Home" }) }), _jsx(PageDebugCard, { payload: props })] })] }));
}
