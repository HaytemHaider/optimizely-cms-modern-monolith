import { jsx as _jsx, jsxs as _jsxs } from "react/jsx-runtime";
import * as Accordion from '@radix-ui/react-accordion';
export function PageDebugCard({ payload }) {
    return (_jsx(Accordion.Root, { type: "single", collapsible: true, className: "rounded-lg border bg-white", children: _jsxs(Accordion.Item, { value: "debug", children: [_jsx(Accordion.Header, { children: _jsx(Accordion.Trigger, { className: "w-full px-4 py-3 text-left text-sm font-medium", children: "Debug payload (CDA-derived)" }) }), _jsx(Accordion.Content, { className: "border-t p-4", children: _jsx("pre", { className: "overflow-x-auto text-xs text-slate-700", children: JSON.stringify(payload, null, 2) }) })] }) }));
}
