import { Icon, type IconProps } from './Icon'

export const Logout: React.FC<IconProps> = (props) => {
  return (
    <Icon viewBox="0 0 24 24" {...props}>
      <mask
        id="mask0_79_22"
        maskUnits="userSpaceOnUse"
        x="0"
        y="0"
        width="24"
        height="24"
      >
        <rect width="24" height="24" fill="inherit" />
      </mask>
      <g mask="url(#mask0_79_22)">
        <path
          d="M20.15 13H8V11H20.15L18.6 9.45L20 8L24 12L20 16L18.6 14.55L20.15 13ZM15 9V5H5V19H15V15H17V19C17 19.55 16.8042 20.0208 16.4125 20.4125C16.0208 20.8042 15.55 21 15 21H5C4.45 21 3.97917 20.8042 3.5875 20.4125C3.19583 20.0208 3 19.55 3 19V5C3 4.45 3.19583 3.97917 3.5875 3.5875C3.97917 3.19583 4.45 3 5 3H15C15.55 3 16.0208 3.19583 16.4125 3.5875C16.8042 3.97917 17 4.45 17 5V9H15Z"
          fill="inherit"
        />
      </g>
    </Icon>
  )
}
