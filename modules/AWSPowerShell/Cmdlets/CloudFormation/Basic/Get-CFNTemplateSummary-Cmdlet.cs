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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Returns information about a new or existing template. The <c>GetTemplateSummary</c>
    /// action is useful for viewing parameter information, such as default parameter values
    /// and parameter types, before you create or update a stack or stack set.
    /// 
    ///  
    /// <para>
    /// You can use the <c>GetTemplateSummary</c> action when you submit a template, or you
    /// can get template information for a stack set, or a running or deleted stack.
    /// </para><para>
    /// For deleted stacks, <c>GetTemplateSummary</c> returns the template information for
    /// up to 90 days after the stack has been deleted. If the template doesn't exist, a <c>ValidationError</c>
    /// is returned.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CFNTemplateSummary")]
    [OutputType("Amazon.CloudFormation.Model.GetTemplateSummaryResponse")]
    [AWSCmdlet("Calls the AWS CloudFormation GetTemplateSummary API operation.", Operation = new[] {"GetTemplateSummary"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.GetTemplateSummaryResponse))]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.GetTemplateSummaryResponse",
        "This cmdlet returns an Amazon.CloudFormation.Model.GetTemplateSummaryResponse object containing multiple properties."
    )]
    public partial class GetCFNTemplateSummaryCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CallAs
        /// <summary>
        /// <para>
        /// <para>[Service-managed permissions] Specifies whether you are acting as an account administrator
        /// in the organization's management account or as a delegated administrator in a member
        /// account.</para><para>By default, <c>SELF</c> is specified. Use <c>SELF</c> for stack sets with self-managed
        /// permissions.</para><ul><li><para>If you are signed in to the management account, specify <c>SELF</c>.</para></li><li><para>If you are signed in to a delegated administrator account, specify <c>DELEGATED_ADMIN</c>.</para><para>Your Amazon Web Services account must be registered as a delegated administrator in
        /// the management account. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-orgs-delegated-admin.html">Register
        /// a delegated administrator</a> in the <i>CloudFormation User Guide</i>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.CallAs")]
        public Amazon.CloudFormation.CallAs CallAs { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>The name or the stack ID that's associated with the stack, which aren't always interchangeable.
        /// For running stacks, you can specify either the stack's name or its unique stack ID.
        /// For deleted stack, you must specify the unique stack ID.</para><para>Conditional: You must specify only one of the following parameters: <c>StackName</c>,
        /// <c>StackSetName</c>, <c>TemplateBody</c>, or <c>TemplateURL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StackName { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name or unique ID of the stack set from which the stack was created.</para><para>Conditional: You must specify only one of the following parameters: <c>StackName</c>,
        /// <c>StackSetName</c>, <c>TemplateBody</c>, or <c>TemplateURL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StackSetName { get; set; }
        #endregion
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>Structure containing the template body with a minimum length of 1 byte and a maximum
        /// length of 51,200 bytes.</para><para>Conditional: You must specify only one of the following parameters: <c>StackName</c>,
        /// <c>StackSetName</c>, <c>TemplateBody</c>, or <c>TemplateURL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateURL
        /// <summary>
        /// <para>
        /// <para>Location of file containing the template body. The URL must point to a template (max
        /// size: 460,800 bytes) that's located in an Amazon S3 bucket or a Systems Manager document.
        /// The location for an Amazon S3 bucket must start with <c>https://</c>.</para><para>Conditional: You must specify only one of the following parameters: <c>StackName</c>,
        /// <c>StackSetName</c>, <c>TemplateBody</c>, or <c>TemplateURL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateURL { get; set; }
        #endregion
        
        #region Parameter TemplateSummaryConfig_TreatUnrecognizedResourceTypesAsWarning
        /// <summary>
        /// <para>
        /// <para>If set to <c>True</c>, any unrecognized resource types generate warnings and not an
        /// error. Any unrecognized resource types are returned in the <c>Warnings</c> output
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TemplateSummaryConfig_TreatUnrecognizedResourceTypesAsWarnings")]
        public System.Boolean? TemplateSummaryConfig_TreatUnrecognizedResourceTypesAsWarning { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.GetTemplateSummaryResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.GetTemplateSummaryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.GetTemplateSummaryResponse, GetCFNTemplateSummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CallAs = this.CallAs;
            context.StackName = this.StackName;
            context.StackSetName = this.StackSetName;
            context.TemplateBody = this.TemplateBody;
            context.TemplateSummaryConfig_TreatUnrecognizedResourceTypesAsWarning = this.TemplateSummaryConfig_TreatUnrecognizedResourceTypesAsWarning;
            context.TemplateURL = this.TemplateURL;
            
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
            var request = new Amazon.CloudFormation.Model.GetTemplateSummaryRequest();
            
            if (cmdletContext.CallAs != null)
            {
                request.CallAs = cmdletContext.CallAs;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
            }
            if (cmdletContext.StackSetName != null)
            {
                request.StackSetName = cmdletContext.StackSetName;
            }
            if (cmdletContext.TemplateBody != null)
            {
                request.TemplateBody = cmdletContext.TemplateBody;
            }
            
             // populate TemplateSummaryConfig
            var requestTemplateSummaryConfigIsNull = true;
            request.TemplateSummaryConfig = new Amazon.CloudFormation.Model.TemplateSummaryConfig();
            System.Boolean? requestTemplateSummaryConfig_templateSummaryConfig_TreatUnrecognizedResourceTypesAsWarning = null;
            if (cmdletContext.TemplateSummaryConfig_TreatUnrecognizedResourceTypesAsWarning != null)
            {
                requestTemplateSummaryConfig_templateSummaryConfig_TreatUnrecognizedResourceTypesAsWarning = cmdletContext.TemplateSummaryConfig_TreatUnrecognizedResourceTypesAsWarning.Value;
            }
            if (requestTemplateSummaryConfig_templateSummaryConfig_TreatUnrecognizedResourceTypesAsWarning != null)
            {
                request.TemplateSummaryConfig.TreatUnrecognizedResourceTypesAsWarnings = requestTemplateSummaryConfig_templateSummaryConfig_TreatUnrecognizedResourceTypesAsWarning.Value;
                requestTemplateSummaryConfigIsNull = false;
            }
             // determine if request.TemplateSummaryConfig should be set to null
            if (requestTemplateSummaryConfigIsNull)
            {
                request.TemplateSummaryConfig = null;
            }
            if (cmdletContext.TemplateURL != null)
            {
                request.TemplateURL = cmdletContext.TemplateURL;
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
        
        private Amazon.CloudFormation.Model.GetTemplateSummaryResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.GetTemplateSummaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "GetTemplateSummary");
            try
            {
                #if DESKTOP
                return client.GetTemplateSummary(request);
                #elif CORECLR
                return client.GetTemplateSummaryAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CloudFormation.CallAs CallAs { get; set; }
            public System.String StackName { get; set; }
            public System.String StackSetName { get; set; }
            public System.String TemplateBody { get; set; }
            public System.Boolean? TemplateSummaryConfig_TreatUnrecognizedResourceTypesAsWarning { get; set; }
            public System.String TemplateURL { get; set; }
            public System.Func<Amazon.CloudFormation.Model.GetTemplateSummaryResponse, GetCFNTemplateSummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
