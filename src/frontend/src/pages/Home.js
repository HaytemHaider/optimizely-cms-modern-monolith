import { jsx as _jsx, jsxs as _jsxs } from "react/jsx-runtime";
import { Link } from '@inertiajs/react';
import { PageDebugCard } from '@/components/PageDebugCard';
import { SiteHeader } from '@/components/SiteHeader';
export default function Home(props) {
    return (_jsxs("main", { children: [_jsx(SiteHeader, {}), _jsxs("div", { className: "mx-auto flex max-w-3xl flex-col gap-4 px-6 py-10", children: [_jsx("h1", { className: "text-3xl font-bold", children: "Home Page" }), _jsx("p", { className: "text-slate-700", children: "This page is routed by Optimizely and rendered by Inertia + React." }), _jsx("div", { children: _jsx(Link, { className: "inline-flex rounded bg-slate-900 px-4 py-2 text-sm font-medium text-white", href: props.links?.subPageUrl ?? '/sub-page', children: "Go to SubPage" }) }), _jsx(PageDebugCard, { payload: props })] })] }));
}
