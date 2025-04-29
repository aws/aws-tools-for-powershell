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
using Amazon.IoTManagedIntegrations;
using Amazon.IoTManagedIntegrations.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTMI
{
    /// <summary>
    /// List all of the associations and statuses for a managed thing by its owner.
    /// </summary>
    [Cmdlet("Get", "IOTMIManagedThingList")]
    [OutputType("Amazon.IoTManagedIntegrations.Model.ManagedThingSummary")]
    [AWSCmdlet("Calls the Managed integrations for AWS IoT Device Management ListManagedThings API operation.", Operation = new[] {"ListManagedThings"}, SelectReturnType = typeof(Amazon.IoTManagedIntegrations.Model.ListManagedThingsResponse))]
    [AWSCmdletOutput("Amazon.IoTManagedIntegrations.Model.ManagedThingSummary or Amazon.IoTManagedIntegrations.Model.ListManagedThingsResponse",
        "This cmdlet returns a collection of Amazon.IoTManagedIntegrations.Model.ManagedThingSummary objects.",
        "The service call response (type Amazon.IoTManagedIntegrations.Model.ListManagedThingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTMIManagedThingListCmdlet : AmazonIoTManagedIntegrationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectorPolicyIdFilter
        /// <summary>
        /// <para>
        /// <para>Filter on a connector policy id for a managed thing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorPolicyIdFilter { get; set; }
        #endregion
        
        #region Parameter CredentialLockerFilter
        /// <summary>
        /// <para>
        /// <para>Filter on a credential locker for a managed thing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CredentialLockerFilter { get; set; }
        #endregion
        
        #region Parameter OwnerFilter
        /// <summary>
        /// <para>
        /// <para>Filter on device owners when listing managed things.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerFilter { get; set; }
        #endregion
        
        #region Parameter ParentControllerIdentifierFilter
        /// <summary>
        /// <para>
        /// <para>Filter on a parent controller id for a managed thing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentControllerIdentifierFilter { get; set; }
        #endregion
        
        #region Parameter ProvisioningStatusFilter
        /// <summary>
        /// <para>
        /// <para>Filter on the status of the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.ProvisioningStatus")]
        public Amazon.IoTManagedIntegrations.ProvisioningStatus ProvisioningStatusFilter { get; set; }
        #endregion
        
        #region Parameter RoleFilter
        /// <summary>
        /// <para>
        /// <para>Filter on the type of device used. This will be the Amazon Web Services hub controller,
        /// cloud device, or IoT device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.Role")]
        public Amazon.IoTManagedIntegrations.Role RoleFilter { get; set; }
        #endregion
        
        #region Parameter SerialNumberFilter
        /// <summary>
        /// <para>
        /// <para>Filter on the serial number of the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SerialNumberFilter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return at one time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token that can be used to retrieve the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTManagedIntegrations.Model.ListManagedThingsResponse).
        /// Specifying the name of a property of type Amazon.IoTManagedIntegrations.Model.ListManagedThingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTManagedIntegrations.Model.ListManagedThingsResponse, GetIOTMIManagedThingListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectorPolicyIdFilter = this.ConnectorPolicyIdFilter;
            context.CredentialLockerFilter = this.CredentialLockerFilter;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.OwnerFilter = this.OwnerFilter;
            context.ParentControllerIdentifierFilter = this.ParentControllerIdentifierFilter;
            context.ProvisioningStatusFilter = this.ProvisioningStatusFilter;
            context.RoleFilter = this.RoleFilter;
            context.SerialNumberFilter = this.SerialNumberFilter;
            
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
            var request = new Amazon.IoTManagedIntegrations.Model.ListManagedThingsRequest();
            
            if (cmdletContext.ConnectorPolicyIdFilter != null)
            {
                request.ConnectorPolicyIdFilter = cmdletContext.ConnectorPolicyIdFilter;
            }
            if (cmdletContext.CredentialLockerFilter != null)
            {
                request.CredentialLockerFilter = cmdletContext.CredentialLockerFilter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.OwnerFilter != null)
            {
                request.OwnerFilter = cmdletContext.OwnerFilter;
            }
            if (cmdletContext.ParentControllerIdentifierFilter != null)
            {
                request.ParentControllerIdentifierFilter = cmdletContext.ParentControllerIdentifierFilter;
            }
            if (cmdletContext.ProvisioningStatusFilter != null)
            {
                request.ProvisioningStatusFilter = cmdletContext.ProvisioningStatusFilter;
            }
            if (cmdletContext.RoleFilter != null)
            {
                request.RoleFilter = cmdletContext.RoleFilter;
            }
            if (cmdletContext.SerialNumberFilter != null)
            {
                request.SerialNumberFilter = cmdletContext.SerialNumberFilter;
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
        
        private Amazon.IoTManagedIntegrations.Model.ListManagedThingsResponse CallAWSServiceOperation(IAmazonIoTManagedIntegrations client, Amazon.IoTManagedIntegrations.Model.ListManagedThingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed integrations for AWS IoT Device Management", "ListManagedThings");
            try
            {
                return client.ListManagedThingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectorPolicyIdFilter { get; set; }
            public System.String CredentialLockerFilter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String OwnerFilter { get; set; }
            public System.String ParentControllerIdentifierFilter { get; set; }
            public Amazon.IoTManagedIntegrations.ProvisioningStatus ProvisioningStatusFilter { get; set; }
            public Amazon.IoTManagedIntegrations.Role RoleFilter { get; set; }
            public System.String SerialNumberFilter { get; set; }
            public System.Func<Amazon.IoTManagedIntegrations.Model.ListManagedThingsResponse, GetIOTMIManagedThingListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
