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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NMGR
{
    /// <summary>
    /// Creates a new link for a specified site.
    /// </summary>
    [Cmdlet("New", "NMGRLink", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkManager.Model.Link")]
    [AWSCmdlet("Calls the AWS Network Manager CreateLink API operation.", Operation = new[] {"CreateLink"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.CreateLinkResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.Link or Amazon.NetworkManager.Model.CreateLinkResponse",
        "This cmdlet returns an Amazon.NetworkManager.Model.Link object.",
        "The service call response (type Amazon.NetworkManager.Model.CreateLinkResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewNMGRLinkCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the link.</para><para>Constraints: Maximum length of 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Bandwidth_DownloadSpeed
        /// <summary>
        /// <para>
        /// <para>Download speed in Mbps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Bandwidth_DownloadSpeed { get; set; }
        #endregion
        
        #region Parameter GlobalNetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the global network.</para>
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
        public System.String GlobalNetworkId { get; set; }
        #endregion
        
        #region Parameter Provider
        /// <summary>
        /// <para>
        /// <para>The provider of the link.</para><para>Constraints: Maximum length of 128 characters. Cannot include the following characters:
        /// | \ ^</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Provider { get; set; }
        #endregion
        
        #region Parameter SiteId
        /// <summary>
        /// <para>
        /// <para>The ID of the site.</para>
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
        public System.String SiteId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the resource during creation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.NetworkManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the link.</para><para>Constraints: Maximum length of 128 characters. Cannot include the following characters:
        /// | \ ^</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Type { get; set; }
        #endregion
        
        #region Parameter Bandwidth_UploadSpeed
        /// <summary>
        /// <para>
        /// <para>Upload speed in Mbps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Bandwidth_UploadSpeed { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Link'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.CreateLinkResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.CreateLinkResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Link";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SiteId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NMGRLink (CreateLink)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.CreateLinkResponse, NewNMGRLinkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Bandwidth_DownloadSpeed = this.Bandwidth_DownloadSpeed;
            context.Bandwidth_UploadSpeed = this.Bandwidth_UploadSpeed;
            context.Description = this.Description;
            context.GlobalNetworkId = this.GlobalNetworkId;
            #if MODULAR
            if (this.GlobalNetworkId == null && ParameterWasBound(nameof(this.GlobalNetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalNetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Provider = this.Provider;
            context.SiteId = this.SiteId;
            #if MODULAR
            if (this.SiteId == null && ParameterWasBound(nameof(this.SiteId)))
            {
                WriteWarning("You are passing $null as a value for parameter SiteId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.NetworkManager.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            
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
            var request = new Amazon.NetworkManager.Model.CreateLinkRequest();
            
            
             // populate Bandwidth
            var requestBandwidthIsNull = true;
            request.Bandwidth = new Amazon.NetworkManager.Model.Bandwidth();
            System.Int32? requestBandwidth_bandwidth_DownloadSpeed = null;
            if (cmdletContext.Bandwidth_DownloadSpeed != null)
            {
                requestBandwidth_bandwidth_DownloadSpeed = cmdletContext.Bandwidth_DownloadSpeed.Value;
            }
            if (requestBandwidth_bandwidth_DownloadSpeed != null)
            {
                request.Bandwidth.DownloadSpeed = requestBandwidth_bandwidth_DownloadSpeed.Value;
                requestBandwidthIsNull = false;
            }
            System.Int32? requestBandwidth_bandwidth_UploadSpeed = null;
            if (cmdletContext.Bandwidth_UploadSpeed != null)
            {
                requestBandwidth_bandwidth_UploadSpeed = cmdletContext.Bandwidth_UploadSpeed.Value;
            }
            if (requestBandwidth_bandwidth_UploadSpeed != null)
            {
                request.Bandwidth.UploadSpeed = requestBandwidth_bandwidth_UploadSpeed.Value;
                requestBandwidthIsNull = false;
            }
             // determine if request.Bandwidth should be set to null
            if (requestBandwidthIsNull)
            {
                request.Bandwidth = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.GlobalNetworkId != null)
            {
                request.GlobalNetworkId = cmdletContext.GlobalNetworkId;
            }
            if (cmdletContext.Provider != null)
            {
                request.Provider = cmdletContext.Provider;
            }
            if (cmdletContext.SiteId != null)
            {
                request.SiteId = cmdletContext.SiteId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.NetworkManager.Model.CreateLinkResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.CreateLinkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "CreateLink");
            try
            {
                return client.CreateLinkAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? Bandwidth_DownloadSpeed { get; set; }
            public System.Int32? Bandwidth_UploadSpeed { get; set; }
            public System.String Description { get; set; }
            public System.String GlobalNetworkId { get; set; }
            public System.String Provider { get; set; }
            public System.String SiteId { get; set; }
            public List<Amazon.NetworkManager.Model.Tag> Tag { get; set; }
            public System.String Type { get; set; }
            public System.Func<Amazon.NetworkManager.Model.CreateLinkResponse, NewNMGRLinkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Link;
        }
        
    }
}
