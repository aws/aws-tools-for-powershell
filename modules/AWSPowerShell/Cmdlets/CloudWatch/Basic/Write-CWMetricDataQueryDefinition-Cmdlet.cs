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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Creates or updates a metric data query definition.
    /// 
    ///  
    /// <para>
    /// A metric data query definition saves a metric query so that you can reuse it later.
    /// It includes the query expression, the query language, and a path that names the definition
    /// and can organize it into folders. When you save a definition, CloudWatch doesn't validate
    /// or run its expression.
    /// </para><para>
    /// To create a definition, omit <c>Id</c>. CloudWatch generates the ID and returns it.
    /// To update a definition, specify its <c>Id</c>. An update replaces the path, expression,
    /// and type, and keeps the creation time.
    /// </para><para>
    /// The path must be unique in your account and Region. If another definition already
    /// uses the path, the request fails with a <c>ConflictException</c>.
    /// </para><para>
    /// You can have up to 1,000 metric data query definitions in each Region of your account.
    /// A request that would create more fails with a <c>LimitExceededException</c>.
    /// </para><para><b>Permissions</b></para><para>
    /// To create or update a definition, you need the <c>cloudwatch:PutMetricDataQueryDefinition</c>
    /// permission on the metric data query definition resource. The resource ARN has the
    /// format <c>arn:aws:cloudwatch:Region:account-id:metric-query-definition/Id</c>.
    /// </para><para>
    /// To add tags when you create a definition, you also need the <c>cloudwatch:TagResource</c>
    /// permission. You can use the <c>aws:RequestTag/${TagKey}</c> and <c>aws:TagKeys</c>
    /// condition keys to control which tags can be added.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWMetricDataQueryDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatch.Model.PutMetricDataQueryDefinitionResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch PutMetricDataQueryDefinition API operation.", Operation = new[] {"PutMetricDataQueryDefinition"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.PutMetricDataQueryDefinitionResponse))]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.PutMetricDataQueryDefinitionResponse",
        "This cmdlet returns an Amazon.CloudWatch.Model.PutMetricDataQueryDefinitionResponse object containing multiple properties."
    )]
    public partial class WriteCWMetricDataQueryDefinitionCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Expression
        /// <summary>
        /// <para>
        /// <para>The query expression, in the language that <c>Type</c> specifies. CloudWatch doesn't
        /// validate or run the expression when you save it.</para>
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
        public System.String Expression { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the metric data query definition to update. Omit this parameter to create
        /// a definition. CloudWatch then generates the ID and returns it in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para>The name of the metric data query definition. Use slashes (<c>/</c>) to organize definitions
        /// into folders, for example <c>team/web/latency</c>. The path must meet the following
        /// requirements:</para><ul><li><para>It must be unique in your account and Region.</para></li><li><para>It can't start or end with a slash.</para></li><li><para>It can't contain an empty folder name (<c>//</c>).</para></li><li><para>It can be at most 1,015 bytes when encoded as UTF-8.</para></li></ul>
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
        public System.String Path { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the metric data query definition. You
        /// can use tags to categorize definitions and to control access to them. Tags are applied
        /// only when the request creates a definition, that is, when you omit <c>Id</c>. To change
        /// the tags of an existing definition, use <c>TagResource</c> and <c>UntagResource</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CloudWatch.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The language of the expression. Valid values are the following:</para><ul><li><para><c>PROMQL</c> – A PromQL query.</para></li><li><para><c>SQL</c> – A CloudWatch Metrics Insights query.</para></li><li><para><c>METRIC_MATH</c> – A metric math expression.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatch.QueryType")]
        public Amazon.CloudWatch.QueryType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.PutMetricDataQueryDefinitionResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.PutMetricDataQueryDefinitionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWMetricDataQueryDefinition (PutMetricDataQueryDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.PutMetricDataQueryDefinitionResponse, WriteCWMetricDataQueryDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Expression = this.Expression;
            #if MODULAR
            if (this.Expression == null && ParameterWasBound(nameof(this.Expression)))
            {
                WriteWarning("You are passing $null as a value for parameter Expression which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            context.Path = this.Path;
            #if MODULAR
            if (this.Path == null && ParameterWasBound(nameof(this.Path)))
            {
                WriteWarning("You are passing $null as a value for parameter Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CloudWatch.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatch.Model.PutMetricDataQueryDefinitionRequest();
            
            if (cmdletContext.Expression != null)
            {
                request.Expression = cmdletContext.Expression;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Path != null)
            {
                request.Path = cmdletContext.Path;
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
        
        private Amazon.CloudWatch.Model.PutMetricDataQueryDefinitionResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.PutMetricDataQueryDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "PutMetricDataQueryDefinition");
            try
            {
                return client.PutMetricDataQueryDefinitionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Expression { get; set; }
            public System.String Id { get; set; }
            public System.String Path { get; set; }
            public List<Amazon.CloudWatch.Model.Tag> Tag { get; set; }
            public Amazon.CloudWatch.QueryType Type { get; set; }
            public System.Func<Amazon.CloudWatch.Model.PutMetricDataQueryDefinitionResponse, WriteCWMetricDataQueryDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
