/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ApplicationInsights;
using Amazon.ApplicationInsights.Model;

namespace Amazon.PowerShell.Cmdlets.CWAI
{
    /// <summary>
    /// Describes the recommended monitoring configuration of the component.
    /// </summary>
    [Cmdlet("Get", "CWAIComponentConfigurationRecommendation")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Insights DescribeComponentConfigurationRecommendation API operation.", Operation = new[] {"DescribeComponentConfigurationRecommendation"}, SelectReturnType = typeof(Amazon.ApplicationInsights.Model.DescribeComponentConfigurationRecommendationResponse))]
    [AWSCmdletOutput("System.String or Amazon.ApplicationInsights.Model.DescribeComponentConfigurationRecommendationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ApplicationInsights.Model.DescribeComponentConfigurationRecommendationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWAIComponentConfigurationRecommendationCmdlet : AmazonApplicationInsightsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ComponentName
        /// <summary>
        /// <para>
        /// <para>The name of the component.</para>
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
        public System.String ComponentName { get; set; }
        #endregion
        
        #region Parameter RecommendationType
        /// <summary>
        /// <para>
        /// <para>The recommended configuration type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationInsights.RecommendationType")]
        public Amazon.ApplicationInsights.RecommendationType RecommendationType { get; set; }
        #endregion
        
        #region Parameter ResourceGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the resource group.</para>
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
        public System.String ResourceGroupName { get; set; }
        #endregion
        
        #region Parameter Tier
        /// <summary>
        /// <para>
        /// <para>The tier of the application component.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ApplicationInsights.Tier")]
        public Amazon.ApplicationInsights.Tier Tier { get; set; }
        #endregion
        
        #region Parameter WorkloadName
        /// <summary>
        /// <para>
        /// <para>The name of the workload. The name of the workload is required when the tier of the
        /// application component is <c>SAP_ASE_SINGLE_NODE</c> or <c>SAP_ASE_HIGH_AVAILABILITY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkloadName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ComponentConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationInsights.Model.DescribeComponentConfigurationRecommendationResponse).
        /// Specifying the name of a property of type Amazon.ApplicationInsights.Model.DescribeComponentConfigurationRecommendationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ComponentConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ComponentName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ComponentName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ComponentName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.ApplicationInsights.Model.DescribeComponentConfigurationRecommendationResponse, GetCWAIComponentConfigurationRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ComponentName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ComponentName = this.ComponentName;
            #if MODULAR
            if (this.ComponentName == null && ParameterWasBound(nameof(this.ComponentName)))
            {
                WriteWarning("You are passing $null as a value for parameter ComponentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecommendationType = this.RecommendationType;
            context.ResourceGroupName = this.ResourceGroupName;
            #if MODULAR
            if (this.ResourceGroupName == null && ParameterWasBound(nameof(this.ResourceGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Tier = this.Tier;
            #if MODULAR
            if (this.Tier == null && ParameterWasBound(nameof(this.Tier)))
            {
                WriteWarning("You are passing $null as a value for parameter Tier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkloadName = this.WorkloadName;
            
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
            var request = new Amazon.ApplicationInsights.Model.DescribeComponentConfigurationRecommendationRequest();
            
            if (cmdletContext.ComponentName != null)
            {
                request.ComponentName = cmdletContext.ComponentName;
            }
            if (cmdletContext.RecommendationType != null)
            {
                request.RecommendationType = cmdletContext.RecommendationType;
            }
            if (cmdletContext.ResourceGroupName != null)
            {
                request.ResourceGroupName = cmdletContext.ResourceGroupName;
            }
            if (cmdletContext.Tier != null)
            {
                request.Tier = cmdletContext.Tier;
            }
            if (cmdletContext.WorkloadName != null)
            {
                request.WorkloadName = cmdletContext.WorkloadName;
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
        
        private Amazon.ApplicationInsights.Model.DescribeComponentConfigurationRecommendationResponse CallAWSServiceOperation(IAmazonApplicationInsights client, Amazon.ApplicationInsights.Model.DescribeComponentConfigurationRecommendationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Insights", "DescribeComponentConfigurationRecommendation");
            try
            {
                #if DESKTOP
                return client.DescribeComponentConfigurationRecommendation(request);
                #elif CORECLR
                return client.DescribeComponentConfigurationRecommendationAsync(request).GetAwaiter().GetResult();
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
            public System.String ComponentName { get; set; }
            public Amazon.ApplicationInsights.RecommendationType RecommendationType { get; set; }
            public System.String ResourceGroupName { get; set; }
            public Amazon.ApplicationInsights.Tier Tier { get; set; }
            public System.String WorkloadName { get; set; }
            public System.Func<Amazon.ApplicationInsights.Model.DescribeComponentConfigurationRecommendationResponse, GetCWAIComponentConfigurationRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ComponentConfiguration;
        }
        
    }
}
