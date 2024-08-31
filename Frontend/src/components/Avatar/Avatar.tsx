export interface AvatarProps extends React.HTMLAttributes<HTMLDivElement> {
  url: string
  width: string | number
  height: string | number
}

export const Avatar: React.FC<AvatarProps> = ({
  url,
  width,
  height,
  style,
  ...props
}) => {
  return (
    <div
      style={{
        width: width,
        height: height,
        borderRadius: 10,
        backgroundImage: `url(${url})`,
        backgroundPosition: 'center center',
        backgroundRepeat: 'no-repeat',
        backgroundSize: 'contain',
        ...style,
      }}
      {...props}
    />
  )
}
