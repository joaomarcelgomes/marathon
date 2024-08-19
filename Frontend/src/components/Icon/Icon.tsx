export interface IconProps extends React.SVGAttributes<SVGElement> {
  size?: number
}

export const Icon: React.FC<IconProps> = ({
  size = 20,
  width = size,
  height = size,
  children,
  ...rest
}) => {
  return (
    <svg
      width={width}
      height={height}
      xmlns="http://www.w3.org/2000/svg"
      fill="#fff"
      {...rest}
    >
      {children}
    </svg>
  )
}
