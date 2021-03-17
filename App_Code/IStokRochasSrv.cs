using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: If you change the interface name "IStokRochasSrv" here, you must also update the reference to "IStokRochasSrv" in Web.config.
[ServiceContract]
public interface IStokRochasSrv
{
	[OperationContract]
	void DoWork();
}
