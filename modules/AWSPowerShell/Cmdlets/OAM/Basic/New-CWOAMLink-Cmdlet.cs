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
using Amazon.OAM;
using Amazon.OAM.Model;

namespace Amazon.PowerShell.Cmdlets.CWOAM
{
    /// <summary>
    /// Creates a link between a source account and a sink that you have created in a monitoring
    /// account. After the link is created, data is sent from the source account to the monitoring
    /// account. When you create a link, you can optionally specify filters that specify which
    /// metric namespaces and which log groups are shared from the source account to the monitoring
    /// account.
    /// 
    ///  
    /// <para>
    /// Before you create a link, you must create a sink in the monitoring account and create
    /// a sink policy in that account. The sink policy must permit the source account to link
    /// to it. You can grant permission to source accounts by granting permission to an entire
    /// organization or to individual accounts.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/OAM/latest/APIReference/API_CreateSink.html">CreateSink</a>
    /// and <a href="https://docs.aws.amazon.com/OAM/latest/APIReference/API_PutSinkPolicy.html">PutSinkPolicy</a>.
    /// </para><para>
    /// Each monitoring account can be linked to as many as 100,000 source accounts.
    /// </para><para>
    /// Each source account can be linked to as many as five monitoring accounts.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CWOAMLink", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OAM.Model.CreateLinkResponse")]
    [AWSCmdlet("Calls the CloudWatch Observability Access Manager CreateLink API operation.", Operation = new[] {"CreateLink"}, SelectReturnType = typeof(Amazon.OAM.Model.CreateLinkResponse))]
    [AWSCmdletOutput("Amazon.OAM.Model.CreateLinkResponse",
        "This cmdlet returns an Amazon.OAM.Model.CreateLinkResponse object containing multiple properties."
    )]
    public partial class NewCWOAMLinkCmdlet : AmazonOAMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter LabelTemplate
        /// <summary>
        /// <para>
        /// <para>Specify a friendly human-readable name to use to identify this source account when
        /// you are viewing data from it in the monitoring account.</para><para>You can use a custom label or use the following variables:</para><ul><li><para><c>$AccountName</c> is the name of the account</para></li><li><para><c>$AccountEmail</c> is the globally unique email address of the account</para></li><li><para><c>$AccountEmailNoDomain</c> is the email address of the account without the domain
        /// name</para></li></ul>
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
        public System.String LabelTemplate { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>An array of strings that define which types of data that the source account shares
        /// with the monitoring account.</para>
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
        
        #region Parameter SinkIdentifier
        /// <summary>
        /// <para>
        /// <para>The ARN of the sink to use to create this link. You can use <a href="https://docs.aws.amazon.com/OAM/latest/APIReference/API_ListSinks.html">ListSinks</a>
        /// to find the ARNs of sinks.</para><para>For more information about sinks, see <a href="https://docs.aws.amazon.com/OAM/latest/APIReference/API_CreateSink.html">CreateSink</a>.</para>
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
        public System.String SinkIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Assigns one or more tags (key-value pairs) to the link. </para><para>Tags can help you organize and categorize your resources. You can also use them to
        /// scope user permissions by granting a user permission to access or change only resources
        /// with certain tag values.</para><para>For more information about using tags to control access, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_tags.html">Controlling
        /// access to Amazon Web Services resources using tags</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OAM.Model.CreateLinkResponse).
        /// Specifying the name of a property of type Amazon.OAM.Model.CreateLinkResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SinkIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWOAMLink (CreateLink)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OAM.Model.CreateLinkResponse, NewCWOAMLinkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LabelTemplate = this.LabelTemplate;
            #if MODULAR
            if (this.LabelTemplate == null && ParameterWasBound(nameof(this.LabelTemplate)))
            {
                WriteWarning("You are passing $null as a value for parameter LabelTemplate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            context.SinkIdentifier = this.SinkIdentifier;
            #if MODULAR
            if (this.SinkIdentifier == null && ParameterWasBound(nameof(this.SinkIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SinkIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.OAM.Model.CreateLinkRequest();
            
            if (cmdletContext.LabelTemplate != null)
            {
                request.LabelTemplate = cmdletContext.LabelTemplate;
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
            if (cmdletContext.SinkIdentifier != null)
            {
                request.SinkIdentifier = cmdletContext.SinkIdentifier;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.OAM.Model.CreateLinkResponse CallAWSServiceOperation(IAmazonOAM client, Amazon.OAM.Model.CreateLinkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Access Manager", "CreateLink");
            try
            {
                #if DESKTOP
                return client.CreateLink(request);
                #elif CORECLR
                return client.CreateLinkAsync(request).GetAwaiter().GetResult();
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
            public System.String LabelTemplate { get; set; }
            public System.String LogGroupConfiguration_Filter { get; set; }
            public System.String MetricConfiguration_Filter { get; set; }
            public List<System.String> ResourceType { get; set; }
            public System.String SinkIdentifier { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.OAM.Model.CreateLinkResponse, NewCWOAMLinkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
