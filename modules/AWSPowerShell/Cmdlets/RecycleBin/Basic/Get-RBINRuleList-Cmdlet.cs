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
using Amazon.RecycleBin;
using Amazon.RecycleBin.Model;

namespace Amazon.PowerShell.Cmdlets.RBIN
{
    /// <summary>
    /// Lists the Recycle Bin retention rules in the Region.
    /// </summary>
    [Cmdlet("Get", "RBINRuleList")]
    [OutputType("Amazon.RecycleBin.Model.RuleSummary")]
    [AWSCmdlet("Calls the Amazon Recycle Bin ListRules API operation.", Operation = new[] {"ListRules"}, SelectReturnType = typeof(Amazon.RecycleBin.Model.ListRulesResponse))]
    [AWSCmdletOutput("Amazon.RecycleBin.Model.RuleSummary or Amazon.RecycleBin.Model.ListRulesResponse",
        "This cmdlet returns a collection of Amazon.RecycleBin.Model.RuleSummary objects.",
        "The service call response (type Amazon.RecycleBin.Model.ListRulesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRBINRuleListCmdlet : AmazonRecycleBinClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExcludeResourceTag
        /// <summary>
        /// <para>
        /// <para>[Region-level retention rules only] Information about the exclusion tags used to identify
        /// resources that are to be excluded, or ignored, by the retention rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExcludeResourceTags")]
        public Amazon.RecycleBin.Model.ResourceTag[] ExcludeResourceTag { get; set; }
        #endregion
        
        #region Parameter LockState
        /// <summary>
        /// <para>
        /// <para>The lock state of the retention rules to list. Only retention rules with the specified
        /// lock state are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RecycleBin.LockState")]
        public Amazon.RecycleBin.LockState LockState { get; set; }
        #endregion
        
        #region Parameter ResourceTag
        /// <summary>
        /// <para>
        /// <para>[Tag-level retention rules only] Information about the resource tags used to identify
        /// resources that are retained by the retention rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTags")]
        public Amazon.RecycleBin.Model.ResourceTag[] ResourceTag { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type retained by the retention rule. Only retention rules that retain
        /// the specified resource type are listed. Currently, only Amazon EBS snapshots and EBS-backed
        /// AMIs are supported. To list retention rules that retain snapshots, specify <c>EBS_SNAPSHOT</c>.
        /// To list retention rules that retain EBS-backed AMIs, specify <c>EC2_IMAGE</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.RecycleBin.ResourceType")]
        public Amazon.RecycleBin.ResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve the remaining
        /// results, make another call with the returned <c>NextToken</c> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Rules'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RecycleBin.Model.ListRulesResponse).
        /// Specifying the name of a property of type Amazon.RecycleBin.Model.ListRulesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Rules";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceType' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RecycleBin.Model.ListRulesResponse, GetRBINRuleListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ExcludeResourceTag != null)
            {
                context.ExcludeResourceTag = new List<Amazon.RecycleBin.Model.ResourceTag>(this.ExcludeResourceTag);
            }
            context.LockState = this.LockState;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.ResourceTag != null)
            {
                context.ResourceTag = new List<Amazon.RecycleBin.Model.ResourceTag>(this.ResourceTag);
            }
            context.ResourceType = this.ResourceType;
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
            var request = new Amazon.RecycleBin.Model.ListRulesRequest();
            
            if (cmdletContext.ExcludeResourceTag != null)
            {
                request.ExcludeResourceTags = cmdletContext.ExcludeResourceTag;
            }
            if (cmdletContext.LockState != null)
            {
                request.LockState = cmdletContext.LockState;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ResourceTag != null)
            {
                request.ResourceTags = cmdletContext.ResourceTag;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
        
        private Amazon.RecycleBin.Model.ListRulesResponse CallAWSServiceOperation(IAmazonRecycleBin client, Amazon.RecycleBin.Model.ListRulesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Recycle Bin", "ListRules");
            try
            {
                #if DESKTOP
                return client.ListRules(request);
                #elif CORECLR
                return client.ListRulesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.RecycleBin.Model.ResourceTag> ExcludeResourceTag { get; set; }
            public Amazon.RecycleBin.LockState LockState { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.RecycleBin.Model.ResourceTag> ResourceTag { get; set; }
            public Amazon.RecycleBin.ResourceType ResourceType { get; set; }
            public System.Func<Amazon.RecycleBin.Model.ListRulesResponse, GetRBINRuleListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Rules;
        }
        
    }
}
