/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Updates the configuration of your Amazon Lightsail container service, such as its
    /// power, scale, and public domain names.
    /// </summary>
    [Cmdlet("Update", "LSContainerService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.ContainerService")]
    [AWSCmdlet("Calls the Amazon Lightsail UpdateContainerService API operation.", Operation = new[] {"UpdateContainerService"}, SelectReturnType = typeof(Amazon.Lightsail.Model.UpdateContainerServiceResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.ContainerService or Amazon.Lightsail.Model.UpdateContainerServiceResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.ContainerService object.",
        "The service call response (type Amazon.Lightsail.Model.UpdateContainerServiceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateLSContainerServiceCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EcrImagePullerRole_IsActive
        /// <summary>
        /// <para>
        /// <para>A Boolean value that indicates whether to activate the role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrivateRegistryAccess_EcrImagePullerRole_IsActive")]
        public System.Boolean? EcrImagePullerRole_IsActive { get; set; }
        #endregion
        
        #region Parameter IsDisabled
        /// <summary>
        /// <para>
        /// <para>A Boolean value to indicate whether the container service is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsDisabled { get; set; }
        #endregion
        
        #region Parameter Power
        /// <summary>
        /// <para>
        /// <para>The power for the container service.</para><para>The power specifies the amount of memory, vCPUs, and base monthly cost of each node
        /// of the container service. The <c>power</c> and <c>scale</c> of a container service
        /// makes up its configured capacity. To determine the monthly price of your container
        /// service, multiply the base price of the <c>power</c> with the <c>scale</c> (the number
        /// of nodes) of the service.</para><para>Use the <c>GetContainerServicePowers</c> action to view the specifications of each
        /// power option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lightsail.ContainerServicePowerName")]
        public Amazon.Lightsail.ContainerServicePowerName Power { get; set; }
        #endregion
        
        #region Parameter PublicDomainName
        /// <summary>
        /// <para>
        /// <para>The public domain names to use with the container service, such as <c>example.com</c>
        /// and <c>www.example.com</c>.</para><para>You can specify up to four public domain names for a container service. The domain
        /// names that you specify are used when you create a deployment with a container configured
        /// as the public endpoint of your container service.</para><para>If you don't specify public domain names, then you can use the default domain of the
        /// container service.</para><important><para>You must create and validate an SSL/TLS certificate before you can use public domain
        /// names with your container service. Use the <c>CreateCertificate</c> action to create
        /// a certificate for the public domain names you want to use with your container service.</para></important><para>You can specify public domain names using a string to array map as shown in the example
        /// later on this page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublicDomainNames")]
        public System.Collections.Hashtable PublicDomainName { get; set; }
        #endregion
        
        #region Parameter Scale
        /// <summary>
        /// <para>
        /// <para>The scale for the container service.</para><para>The scale specifies the allocated compute nodes of the container service. The <c>power</c>
        /// and <c>scale</c> of a container service makes up its configured capacity. To determine
        /// the monthly price of your container service, multiply the base price of the <c>power</c>
        /// with the <c>scale</c> (the number of nodes) of the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Scale { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the container service to update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContainerService'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.UpdateContainerServiceResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.UpdateContainerServiceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContainerService";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LSContainerService (UpdateContainerService)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.UpdateContainerServiceResponse, UpdateLSContainerServiceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IsDisabled = this.IsDisabled;
            context.Power = this.Power;
            context.EcrImagePullerRole_IsActive = this.EcrImagePullerRole_IsActive;
            if (this.PublicDomainName != null)
            {
                context.PublicDomainName = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.PublicDomainName.Keys)
                {
                    object hashValue = this.PublicDomainName[hashKey];
                    if (hashValue == null)
                    {
                        context.PublicDomainName.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.PublicDomainName.Add((String)hashKey, valueSet);
                }
            }
            context.Scale = this.Scale;
            context.ServiceName = this.ServiceName;
            #if MODULAR
            if (this.ServiceName == null && ParameterWasBound(nameof(this.ServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Lightsail.Model.UpdateContainerServiceRequest();
            
            if (cmdletContext.IsDisabled != null)
            {
                request.IsDisabled = cmdletContext.IsDisabled.Value;
            }
            if (cmdletContext.Power != null)
            {
                request.Power = cmdletContext.Power;
            }
            
             // populate PrivateRegistryAccess
            var requestPrivateRegistryAccessIsNull = true;
            request.PrivateRegistryAccess = new Amazon.Lightsail.Model.PrivateRegistryAccessRequest();
            Amazon.Lightsail.Model.ContainerServiceECRImagePullerRoleRequest requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole = null;
            
             // populate EcrImagePullerRole
            var requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRoleIsNull = true;
            requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole = new Amazon.Lightsail.Model.ContainerServiceECRImagePullerRoleRequest();
            System.Boolean? requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole_ecrImagePullerRole_IsActive = null;
            if (cmdletContext.EcrImagePullerRole_IsActive != null)
            {
                requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole_ecrImagePullerRole_IsActive = cmdletContext.EcrImagePullerRole_IsActive.Value;
            }
            if (requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole_ecrImagePullerRole_IsActive != null)
            {
                requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole.IsActive = requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole_ecrImagePullerRole_IsActive.Value;
                requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRoleIsNull = false;
            }
             // determine if requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole should be set to null
            if (requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRoleIsNull)
            {
                requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole = null;
            }
            if (requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole != null)
            {
                request.PrivateRegistryAccess.EcrImagePullerRole = requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole;
                requestPrivateRegistryAccessIsNull = false;
            }
             // determine if request.PrivateRegistryAccess should be set to null
            if (requestPrivateRegistryAccessIsNull)
            {
                request.PrivateRegistryAccess = null;
            }
            if (cmdletContext.PublicDomainName != null)
            {
                request.PublicDomainNames = cmdletContext.PublicDomainName;
            }
            if (cmdletContext.Scale != null)
            {
                request.Scale = cmdletContext.Scale.Value;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Lightsail.Model.UpdateContainerServiceResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.UpdateContainerServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "UpdateContainerService");
            try
            {
                #if DESKTOP
                return client.UpdateContainerService(request);
                #elif CORECLR
                return client.UpdateContainerServiceAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.Boolean? IsDisabled { get; set; }
            public Amazon.Lightsail.ContainerServicePowerName Power { get; set; }
            public System.Boolean? EcrImagePullerRole_IsActive { get; set; }
            public Dictionary<System.String, List<System.String>> PublicDomainName { get; set; }
            public System.Int32? Scale { get; set; }
            public System.String ServiceName { get; set; }
            public System.Func<Amazon.Lightsail.Model.UpdateContainerServiceResponse, UpdateLSContainerServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContainerService;
        }
        
    }
}
