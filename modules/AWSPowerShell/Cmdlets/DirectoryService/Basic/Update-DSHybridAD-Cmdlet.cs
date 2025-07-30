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
using System.Threading;
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Updates the configuration of an existing hybrid directory. You can recover hybrid
    /// directory administrator account or modify self-managed instance settings.
    /// 
    ///  
    /// <para>
    /// Updates are applied asynchronously. Use <a>DescribeHybridADUpdate</a> to monitor the
    /// progress of configuration changes.
    /// </para><para>
    /// The <c>InstanceIds</c> must have a one-to-one correspondence with <c>CustomerDnsIps</c>,
    /// meaning that if the IP address for instance i-10243410 is 10.24.34.100 and the IP
    /// address for instance i-10243420 is 10.24.34.200, then the input arrays must maintain
    /// the same order relationship, either [10.24.34.100, 10.24.34.200] paired with [i-10243410,
    /// i-10243420] or [10.24.34.200, 10.24.34.100] paired with [i-10243420, i-10243410].
    /// </para><note><para>
    /// You must provide at least one update to <a>UpdateHybridADRequest$HybridAdministratorAccountUpdate</a>
    /// or <a>UpdateHybridADRequest$SelfManagedInstancesSettings</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "DSHybridAD", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectoryService.Model.UpdateHybridADResponse")]
    [AWSCmdlet("Calls the AWS Directory Service UpdateHybridAD API operation.", Operation = new[] {"UpdateHybridAD"}, SelectReturnType = typeof(Amazon.DirectoryService.Model.UpdateHybridADResponse))]
    [AWSCmdletOutput("Amazon.DirectoryService.Model.UpdateHybridADResponse",
        "This cmdlet returns an Amazon.DirectoryService.Model.UpdateHybridADResponse object containing multiple properties."
    )]
    public partial class UpdateDSHybridADCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SelfManagedInstancesSettings_CustomerDnsIp
        /// <summary>
        /// <para>
        /// <para>The IP addresses of the DNS servers or domain controllers in your self-managed AD
        /// environment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelfManagedInstancesSettings_CustomerDnsIps")]
        public System.String[] SelfManagedInstancesSettings_CustomerDnsIp { get; set; }
        #endregion
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the hybrid directory to update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter SelfManagedInstancesSettings_InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the self-managed instances with SSM used in hybrid directory.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelfManagedInstancesSettings_InstanceIds")]
        public System.String[] SelfManagedInstancesSettings_InstanceId { get; set; }
        #endregion
        
        #region Parameter HybridAdministratorAccountUpdate_SecretArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Secrets Manager secret that
        /// contains the credentials for the AD administrator user, and enables hybrid domain
        /// controllers to join the managed AD domain. For example:</para><para><c> {"customerAdAdminDomainUsername":"carlos_salazar","customerAdAdminDomainPassword":"ExamplePassword123!"}.
        /// </c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HybridAdministratorAccountUpdate_SecretArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryService.Model.UpdateHybridADResponse).
        /// Specifying the name of a property of type Amazon.DirectoryService.Model.UpdateHybridADResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DirectoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DSHybridAD (UpdateHybridAD)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectoryService.Model.UpdateHybridADResponse, UpdateDSHybridADCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DirectoryId = this.DirectoryId;
            #if MODULAR
            if (this.DirectoryId == null && ParameterWasBound(nameof(this.DirectoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HybridAdministratorAccountUpdate_SecretArn = this.HybridAdministratorAccountUpdate_SecretArn;
            if (this.SelfManagedInstancesSettings_CustomerDnsIp != null)
            {
                context.SelfManagedInstancesSettings_CustomerDnsIp = new List<System.String>(this.SelfManagedInstancesSettings_CustomerDnsIp);
            }
            if (this.SelfManagedInstancesSettings_InstanceId != null)
            {
                context.SelfManagedInstancesSettings_InstanceId = new List<System.String>(this.SelfManagedInstancesSettings_InstanceId);
            }
            
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
            var request = new Amazon.DirectoryService.Model.UpdateHybridADRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            
             // populate HybridAdministratorAccountUpdate
            var requestHybridAdministratorAccountUpdateIsNull = true;
            request.HybridAdministratorAccountUpdate = new Amazon.DirectoryService.Model.HybridAdministratorAccountUpdate();
            System.String requestHybridAdministratorAccountUpdate_hybridAdministratorAccountUpdate_SecretArn = null;
            if (cmdletContext.HybridAdministratorAccountUpdate_SecretArn != null)
            {
                requestHybridAdministratorAccountUpdate_hybridAdministratorAccountUpdate_SecretArn = cmdletContext.HybridAdministratorAccountUpdate_SecretArn;
            }
            if (requestHybridAdministratorAccountUpdate_hybridAdministratorAccountUpdate_SecretArn != null)
            {
                request.HybridAdministratorAccountUpdate.SecretArn = requestHybridAdministratorAccountUpdate_hybridAdministratorAccountUpdate_SecretArn;
                requestHybridAdministratorAccountUpdateIsNull = false;
            }
             // determine if request.HybridAdministratorAccountUpdate should be set to null
            if (requestHybridAdministratorAccountUpdateIsNull)
            {
                request.HybridAdministratorAccountUpdate = null;
            }
            
             // populate SelfManagedInstancesSettings
            var requestSelfManagedInstancesSettingsIsNull = true;
            request.SelfManagedInstancesSettings = new Amazon.DirectoryService.Model.HybridCustomerInstancesSettings();
            List<System.String> requestSelfManagedInstancesSettings_selfManagedInstancesSettings_CustomerDnsIp = null;
            if (cmdletContext.SelfManagedInstancesSettings_CustomerDnsIp != null)
            {
                requestSelfManagedInstancesSettings_selfManagedInstancesSettings_CustomerDnsIp = cmdletContext.SelfManagedInstancesSettings_CustomerDnsIp;
            }
            if (requestSelfManagedInstancesSettings_selfManagedInstancesSettings_CustomerDnsIp != null)
            {
                request.SelfManagedInstancesSettings.CustomerDnsIps = requestSelfManagedInstancesSettings_selfManagedInstancesSettings_CustomerDnsIp;
                requestSelfManagedInstancesSettingsIsNull = false;
            }
            List<System.String> requestSelfManagedInstancesSettings_selfManagedInstancesSettings_InstanceId = null;
            if (cmdletContext.SelfManagedInstancesSettings_InstanceId != null)
            {
                requestSelfManagedInstancesSettings_selfManagedInstancesSettings_InstanceId = cmdletContext.SelfManagedInstancesSettings_InstanceId;
            }
            if (requestSelfManagedInstancesSettings_selfManagedInstancesSettings_InstanceId != null)
            {
                request.SelfManagedInstancesSettings.InstanceIds = requestSelfManagedInstancesSettings_selfManagedInstancesSettings_InstanceId;
                requestSelfManagedInstancesSettingsIsNull = false;
            }
             // determine if request.SelfManagedInstancesSettings should be set to null
            if (requestSelfManagedInstancesSettingsIsNull)
            {
                request.SelfManagedInstancesSettings = null;
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
        
        private Amazon.DirectoryService.Model.UpdateHybridADResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.UpdateHybridADRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "UpdateHybridAD");
            try
            {
                return client.UpdateHybridADAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DirectoryId { get; set; }
            public System.String HybridAdministratorAccountUpdate_SecretArn { get; set; }
            public List<System.String> SelfManagedInstancesSettings_CustomerDnsIp { get; set; }
            public List<System.String> SelfManagedInstancesSettings_InstanceId { get; set; }
            public System.Func<Amazon.DirectoryService.Model.UpdateHybridADResponse, UpdateDSHybridADCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
