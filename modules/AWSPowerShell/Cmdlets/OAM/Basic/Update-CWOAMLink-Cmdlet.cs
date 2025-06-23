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
using Amazon.OAM;
using Amazon.OAM.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWOAM
{
    /// <summary>
    /// Use this operation to change what types of data are shared from a source account to
    /// its linked monitoring account sink. You can't change the sink or change the monitoring
    /// account with this operation.
    /// 
    ///  
    /// <para>
    /// When you update a link, you can optionally specify filters that specify which metric
    /// namespaces and which log groups are shared from the source account to the monitoring
    /// account.
    /// </para><para>
    /// To update the list of tags associated with the sink, use <a href="https://docs.aws.amazon.com/OAM/latest/APIReference/API_TagResource.html">TagResource</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CWOAMLink", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OAM.Model.UpdateLinkResponse")]
    [AWSCmdlet("Calls the CloudWatch Observability Access Manager UpdateLink API operation.", Operation = new[] {"UpdateLink"}, SelectReturnType = typeof(Amazon.OAM.Model.UpdateLinkResponse))]
    [AWSCmdletOutput("Amazon.OAM.Model.UpdateLinkResponse",
        "This cmdlet returns an Amazon.OAM.Model.UpdateLinkResponse object containing multiple properties."
    )]
    public partial class UpdateCWOAMLinkCmdlet : AmazonOAMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LogGroupConfiguration_Filter
        /// <summary>
        /// <para>
        /// <para>Use this field to specify which log groups are to share their log events with the
        /// monitoring account. Use the term <c>LogGroupName</c> and one or more of the following
        /// operands. Use single quotation marks (') around log group names. The matching of log
        /// group names is case sensitive. Each filter has a limit of five conditional operands.
        /// Conditional operands are <c>AND</c> and <c>OR</c>.</para><ul><li><para><c>=</c> and <c>!=</c></para></li><li><para><c>AND</c></para></li><li><para><c>OR</c></para></li><li><para><c>LIKE</c> and <c>NOT LIKE</c>. These can be used only as prefix searches. Include
        /// a <c>%</c> at the end of the string that you want to search for and include.</para></li><li><para><c>IN</c> and <c>NOT IN</c>, using parentheses <c>( )</c></para></li></ul><para>Examples:</para><ul><li><para><c>LogGroupName IN ('This-Log-Group', 'Other-Log-Group')</c> includes only the log
        /// groups with names <c>This-Log-Group</c> and <c>Other-Log-Group</c>.</para></li><li><para><c>LogGroupName NOT IN ('Private-Log-Group', 'Private-Log-Group-2')</c> includes
        /// all log groups except the log groups with names <c>Private-Log-Group</c> and <c>Private-Log-Group-2</c>.</para></li><li><para><c>LogGroupName LIKE 'aws/lambda/%' OR LogGroupName LIKE 'AWSLogs%'</c> includes
        /// all log groups that have names that start with <c>aws/lambda/</c> or <c>AWSLogs</c>.</para></li></ul><note><para>If you are updating a link that uses filters, you can specify <c>*</c> as the only
        /// value for the <c>filter</c> parameter to delete the filter and share all log groups
        /// with the monitoring account.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LinkConfiguration_LogGroupConfiguration_Filter")]
        public System.String LogGroupConfiguration_Filter { get; set; }
        #endregion
        
        #region Parameter MetricConfiguration_Filter
        /// <summary>
        /// <para>
        /// <para>Use this field to specify which metrics are to be shared with the monitoring account.
        /// Use the term <c>Namespace</c> and one or more of the following operands. Use single
        /// quotation marks (') around namespace names. The matching of namespace names is case
        /// sensitive. Each filter has a limit of five conditional operands. Conditional operands
        /// are <c>AND</c> and <c>OR</c>.</para><ul><li><para><c>=</c> and <c>!=</c></para></li><li><para><c>AND</c></para></li><li><para><c>OR</c></para></li><li><para><c>LIKE</c> and <c>NOT LIKE</c>. These can be used only as prefix searches. Include
        /// a <c>%</c> at the end of the string that you want to search for and include.</para></li><li><para><c>IN</c> and <c>NOT IN</c>, using parentheses <c>( )</c></para></li></ul><para>Examples:</para><ul><li><para><c>Namespace NOT LIKE 'AWS/%'</c> includes only namespaces that don't start with
        /// <c>AWS/</c>, such as custom namespaces.</para></li><li><para><c>Namespace IN ('AWS/EC2', 'AWS/ELB', 'AWS/S3')</c> includes only the metrics in
        /// the EC2, Elastic Load Balancing, and Amazon S3 namespaces. </para></li><li><para><c>Namespace = 'AWS/EC2' OR Namespace NOT LIKE 'AWS/%'</c> includes only the EC2
        /// namespace and your custom namespaces.</para></li></ul><note><para>If you are updating a link that uses filters, you can specify <c>*</c> as the only
        /// value for the <c>filter</c> parameter to delete the filter and share all metric namespaces
        /// with the monitoring account.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LinkConfiguration_MetricConfiguration_Filter")]
        public System.String MetricConfiguration_Filter { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The ARN of the link that you want to update.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter IncludeTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include the tags associated with the link in the response after
        /// the update operation. When <c>IncludeTags</c> is set to <c>true</c> and the caller
        /// has the required permission, <c>oam:ListTagsForResource</c>, the API will return the
        /// tags for the specified resource. If the caller doesn't have the required permission,
        /// <c>oam:ListTagsForResource</c>, the API will raise an exception. </para><para>The default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeTags")]
        public System.Boolean? IncludeTag { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>An array of strings that define which types of data that the source account will send
        /// to the monitoring account.</para><para>Your input here replaces the current set of data types that are shared.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ResourceTypes")]
        public System.String[] ResourceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OAM.Model.UpdateLinkResponse).
        /// Specifying the name of a property of type Amazon.OAM.Model.UpdateLinkResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWOAMLink (UpdateLink)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OAM.Model.UpdateLinkResponse, UpdateCWOAMLinkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IncludeTag = this.IncludeTag;
            context.LogGroupConfiguration_Filter = this.LogGroupConfiguration_Filter;
            context.MetricConfiguration_Filter = this.MetricConfiguration_Filter;
            if (this.ResourceType != null)
            {
                context.ResourceType = new List<System.String>(this.ResourceType);
            }
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OAM.Model.UpdateLinkRequest();
            
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.IncludeTag != null)
            {
                request.IncludeTags = cmdletContext.IncludeTag.Value;
            }
            
             // populate LinkConfiguration
            var requestLinkConfigurationIsNull = true;
            request.LinkConfiguration = new Amazon.OAM.Model.LinkConfiguration();
            Amazon.OAM.Model.LogGroupConfiguration requestLinkConfiguration_linkConfiguration_LogGroupConfiguration = null;
            
             // populate LogGroupConfiguration
            var requestLinkConfiguration_linkConfiguration_LogGroupConfigurationIsNull = true;
            requestLinkConfiguration_linkConfiguration_LogGroupConfiguration = new Amazon.OAM.Model.LogGroupConfiguration();
            System.String requestLinkConfiguration_linkConfiguration_LogGroupConfiguration_logGroupConfiguration_Filter = null;
            if (cmdletContext.LogGroupConfiguration_Filter != null)
            {
                requestLinkConfiguration_linkConfiguration_LogGroupConfiguration_logGroupConfiguration_Filter = cmdletContext.LogGroupConfiguration_Filter;
            }
            if (requestLinkConfiguration_linkConfiguration_LogGroupConfiguration_logGroupConfiguration_Filter != null)
            {
                requestLinkConfiguration_linkConfiguration_LogGroupConfiguration.Filter = requestLinkConfiguration_linkConfiguration_LogGroupConfiguration_logGroupConfiguration_Filter;
                requestLinkConfiguration_linkConfiguration_LogGroupConfigurationIsNull = false;
            }
             // determine if requestLinkConfiguration_linkConfiguration_LogGroupConfiguration should be set to null
            if (requestLinkConfiguration_linkConfiguration_LogGroupConfigurationIsNull)
            {
                requestLinkConfiguration_linkConfiguration_LogGroupConfiguration = null;
            }
            if (requestLinkConfiguration_linkConfiguration_LogGroupConfiguration != null)
            {
                request.LinkConfiguration.LogGroupConfiguration = requestLinkConfiguration_linkConfiguration_LogGroupConfiguration;
                requestLinkConfigurationIsNull = false;
            }
            Amazon.OAM.Model.MetricConfiguration requestLinkConfiguration_linkConfiguration_MetricConfiguration = null;
            
             // populate MetricConfiguration
            var requestLinkConfiguration_linkConfiguration_MetricConfigurationIsNull = true;
            requestLinkConfiguration_linkConfiguration_MetricConfiguration = new Amazon.OAM.Model.MetricConfiguration();
            System.String requestLinkConfiguration_linkConfiguration_MetricConfiguration_metricConfiguration_Filter = null;
            if (cmdletContext.MetricConfiguration_Filter != null)
            {
                requestLinkConfiguration_linkConfiguration_MetricConfiguration_metricConfiguration_Filter = cmdletContext.MetricConfiguration_Filter;
            }
            if (requestLinkConfiguration_linkConfiguration_MetricConfiguration_metricConfiguration_Filter != null)
            {
                requestLinkConfiguration_linkConfiguration_MetricConfiguration.Filter = requestLinkConfiguration_linkConfiguration_MetricConfiguration_metricConfiguration_Filter;
                requestLinkConfiguration_linkConfiguration_MetricConfigurationIsNull = false;
            }
             // determine if requestLinkConfiguration_linkConfiguration_MetricConfiguration should be set to null
            if (requestLinkConfiguration_linkConfiguration_MetricConfigurationIsNull)
            {
                requestLinkConfiguration_linkConfiguration_MetricConfiguration = null;
            }
            if (requestLinkConfiguration_linkConfiguration_MetricConfiguration != null)
            {
                request.LinkConfiguration.MetricConfiguration = requestLinkConfiguration_linkConfiguration_MetricConfiguration;
                requestLinkConfigurationIsNull = false;
            }
             // determine if request.LinkConfiguration should be set to null
            if (requestLinkConfigurationIsNull)
            {
                request.LinkConfiguration = null;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceTypes = cmdletContext.ResourceType;
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
        
        private Amazon.OAM.Model.UpdateLinkResponse CallAWSServiceOperation(IAmazonOAM client, Amazon.OAM.Model.UpdateLinkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Access Manager", "UpdateLink");
            try
            {
                return client.UpdateLinkAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Identifier { get; set; }
            public System.Boolean? IncludeTag { get; set; }
            public System.String LogGroupConfiguration_Filter { get; set; }
            public System.String MetricConfiguration_Filter { get; set; }
            public List<System.String> ResourceType { get; set; }
            public System.Func<Amazon.OAM.Model.UpdateLinkResponse, UpdateCWOAMLinkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
