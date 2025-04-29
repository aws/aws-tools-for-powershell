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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the ID format for the specified resource on a per-Region basis. You can specify
    /// that resources should receive longer IDs (17-character IDs) when they are created.
    /// 
    ///  
    /// <para>
    /// This request can only be used to modify longer ID settings for resource types that
    /// are within the opt-in period. Resources currently in their opt-in period include:
    /// <c>bundle</c> | <c>conversion-task</c> | <c>customer-gateway</c> | <c>dhcp-options</c>
    /// | <c>elastic-ip-allocation</c> | <c>elastic-ip-association</c> | <c>export-task</c>
    /// | <c>flow-log</c> | <c>image</c> | <c>import-task</c> | <c>internet-gateway</c> |
    /// <c>network-acl</c> | <c>network-acl-association</c> | <c>network-interface</c> | <c>network-interface-attachment</c>
    /// | <c>prefix-list</c> | <c>route-table</c> | <c>route-table-association</c> | <c>security-group</c>
    /// | <c>subnet</c> | <c>subnet-cidr-block-association</c> | <c>vpc</c> | <c>vpc-cidr-block-association</c>
    /// | <c>vpc-endpoint</c> | <c>vpc-peering-connection</c> | <c>vpn-connection</c> | <c>vpn-gateway</c>.
    /// </para><para>
    /// This setting applies to the IAM user who makes the request; it does not apply to the
    /// entire Amazon Web Services account. By default, an IAM user defaults to the same settings
    /// as the root user. If you're using this action as the root user, then these settings
    /// apply to the entire account, unless an IAM user explicitly overrides these settings
    /// for themselves. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/resource-ids.html">Resource
    /// IDs</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para><para>
    /// Resources created with longer IDs are visible to all IAM roles and users, regardless
    /// of these settings and provided that they have permission to use the relevant <c>Describe</c>
    /// command for the resource type.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2IdFormat", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyIdFormat API operation.", Operation = new[] {"ModifyIdFormat"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyIdFormatResponse))]
    [AWSCmdletOutput("None or Amazon.EC2.Model.ModifyIdFormatResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.EC2.Model.ModifyIdFormatResponse) be returned by specifying '-Select *'."
    )]
    public partial class EditEC2IdFormatCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The type of resource: <c>bundle</c> | <c>conversion-task</c> | <c>customer-gateway</c>
        /// | <c>dhcp-options</c> | <c>elastic-ip-allocation</c> | <c>elastic-ip-association</c>
        /// | <c>export-task</c> | <c>flow-log</c> | <c>image</c> | <c>import-task</c> | <c>internet-gateway</c>
        /// | <c>network-acl</c> | <c>network-acl-association</c> | <c>network-interface</c> |
        /// <c>network-interface-attachment</c> | <c>prefix-list</c> | <c>route-table</c> | <c>route-table-association</c>
        /// | <c>security-group</c> | <c>subnet</c> | <c>subnet-cidr-block-association</c> | <c>vpc</c>
        /// | <c>vpc-cidr-block-association</c> | <c>vpc-endpoint</c> | <c>vpc-peering-connection</c>
        /// | <c>vpn-connection</c> | <c>vpn-gateway</c>.</para><para>Alternatively, use the <c>all-current</c> option to include all resource types that
        /// are currently within their opt-in period for longer IDs.</para>
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
        public System.String Resource { get; set; }
        #endregion
        
        #region Parameter UseLongId
        /// <summary>
        /// <para>
        /// <para>Indicate whether the resource should use longer IDs (17-character IDs).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("UseLongIds")]
        public System.Boolean? UseLongId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyIdFormatResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UseLongId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2IdFormat (ModifyIdFormat)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyIdFormatResponse, EditEC2IdFormatCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Resource = this.Resource;
            #if MODULAR
            if (this.Resource == null && ParameterWasBound(nameof(this.Resource)))
            {
                WriteWarning("You are passing $null as a value for parameter Resource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UseLongId = this.UseLongId;
            #if MODULAR
            if (this.UseLongId == null && ParameterWasBound(nameof(this.UseLongId)))
            {
                WriteWarning("You are passing $null as a value for parameter UseLongId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyIdFormatRequest();
            
            if (cmdletContext.Resource != null)
            {
                request.Resource = cmdletContext.Resource;
            }
            if (cmdletContext.UseLongId != null)
            {
                request.UseLongIds = cmdletContext.UseLongId.Value;
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
        
        private Amazon.EC2.Model.ModifyIdFormatResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyIdFormatRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyIdFormat");
            try
            {
                return client.ModifyIdFormatAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Resource { get; set; }
            public System.Boolean? UseLongId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyIdFormatResponse, EditEC2IdFormatCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
