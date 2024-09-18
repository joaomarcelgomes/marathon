import { Icon, type IconProps } from './Icon'

export const Edit: React.FC<IconProps> = (props) => {
  return (
    <Icon viewBox="0 0 24 24" {...props}>
      <mask
        id="mask0_100_404"
        style={{ maskType: 'alpha' }}
        maskUnits="userSpaceOnUse"
        x="0"
        y="0"
        width="24"
        height="24"
      >
        <rect width="24" height="24" fill="inherit" />
      </mask>
      <g mask="url(#mask0_100_404)">
        <path
          d="M4.17497 20.9999C3.82497 21.0832 3.5208 20.9957 3.26247 20.7374C3.00414 20.4791 2.91664 20.1749 2.99997 19.8249L3.99997 15.0499L8.94997 19.9999L4.17497 20.9999ZM8.94997 19.9999L3.99997 15.0499L15.45 3.5999C15.8333 3.21657 16.3083 3.0249 16.875 3.0249C17.4416 3.0249 17.9166 3.21657 18.3 3.5999L20.4 5.6999C20.7833 6.08324 20.975 6.55824 20.975 7.1249C20.975 7.69157 20.7833 8.16657 20.4 8.5499L8.94997 19.9999ZM16.875 4.9999L6.52497 15.3499L8.64997 17.4749L19 7.1249L16.875 4.9999Z"
          fill="inherit"
        />
      </g>
    </Icon>
  )
}
