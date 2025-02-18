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
using Amazon.Billing;
using Amazon.Billing.Model;

namespace Amazon.PowerShell.Cmdlets.AWSB
{
    /// <summary>
    /// An API to update the attributes of the billing view.
    /// </summary>
    [Cmdlet("Update", "AWSBBillingView", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Billing.Model.UpdateBillingViewResponse")]
    [AWSCmdlet("Calls the AWS Billing UpdateBillingView API operation.", Operation = new[] {"UpdateBillingView"}, SelectReturnType = typeof(Amazon.Billing.Model.UpdateBillingViewResponse))]
    [AWSCmdletOutput("Amazon.Billing.Model.UpdateBillingViewResponse",
        "This cmdlet returns an Amazon.Billing.Model.UpdateBillingViewResponse object containing multiple properties."
    )]
    public partial class UpdateAWSBBillingViewCmdlet : AmazonBillingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) that can be used to uniquely identify the billing
        /// view. </para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The description of the billing view. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Dimensions_Key
        /// <summary>
        /// <para>
        /// <para> The names of the metadata types that you can use to filter and group your results.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataFilterExpression_Dimensions_Key")]
        [AWSConstantClassSource("Amazon.Billing.Dimension")]
        public Amazon.Billing.Dimension Dimensions_Key { get; set; }
        #endregion
        
        #region Parameter Tags_Key
        /// <summary>
        /// <para>
        /// <para> The key for the tag. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataFilterExpression_Tags_Key")]
        public System.String Tags_Key { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The name of the billing view. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Dimensions_Value
        /// <summary>
        /// <para>
        /// <para> The metadata values that you can use to filter and group your results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataFilterExpression_Dimensions_Values")]
        public System.String[] Dimensions_Value { get; set; }
        #endregion
        
        #region Parameter Tags_Value
        /// <summary>
        /// <para>
        /// <para> The specific value of the tag. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataFilterExpression_Tags_Values")]
        public System.String[] Tags_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Billing.Model.UpdateBillingViewResponse).
        /// Specifying the name of a property of type Amazon.Billing.Model.UpdateBillingViewResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AWSBBillingView (UpdateBillingView)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Billing.Model.UpdateBillingViewResponse, UpdateAWSBBillingViewCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Dimensions_Key = this.Dimensions_Key;
            if (this.Dimensions_Value != null)
            {
                context.Dimensions_Value = new List<System.String>(this.Dimensions_Value);
            }
            context.Tags_Key = this.Tags_Key;
            if (this.Tags_Value != null)
            {
                context.Tags_Value = new List<System.String>(this.Tags_Value);
            }
            context.Description = this.Description;
            context.Name = this.Name;
            
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
            var request = new Amazon.Billing.Model.UpdateBillingViewRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            
             // populate DataFilterExpression
            var requestDataFilterExpressionIsNull = true;
            request.DataFilterExpression = new Amazon.Billing.Model.Expression();
            Amazon.Billing.Model.DimensionValues requestDataFilterExpression_dataFilterExpression_Dimensions = null;
            
             // populate Dimensions
            var requestDataFilterExpression_dataFilterExpression_DimensionsIsNull = true;
            requestDataFilterExpression_dataFilterExpression_Dimensions = new Amazon.Billing.Model.DimensionValues();
            Amazon.Billing.Dimension requestDataFilterExpression_dataFilterExpression_Dimensions_dimensions_Key = null;
            if (cmdletContext.Dimensions_Key != null)
            {
                requestDataFilterExpression_dataFilterExpression_Dimensions_dimensions_Key = cmdletContext.Dimensions_Key;
            }
            if (requestDataFilterExpression_dataFilterExpression_Dimensions_dimensions_Key != null)
            {
                requestDataFilterExpression_dataFilterExpression_Dimensions.Key = requestDataFilterExpression_dataFilterExpression_Dimensions_dimensions_Key;
                requestDataFilterExpression_dataFilterExpression_DimensionsIsNull = false;
            }
            List<System.String> requestDataFilterExpression_dataFilterExpression_Dimensions_dimensions_Value = null;
            if (cmdletContext.Dimensions_Value != null)
            {
                requestDataFilterExpression_dataFilterExpression_Dimensions_dimensions_Value = cmdletContext.Dimensions_Value;
            }
            if (requestDataFilterExpression_dataFilterExpression_Dimensions_dimensions_Value != null)
            {
                requestDataFilterExpression_dataFilterExpression_Dimensions.Values = requestDataFilterExpression_dataFilterExpression_Dimensions_dimensions_Value;
                requestDataFilterExpression_dataFilterExpression_DimensionsIsNull = false;
            }
             // determine if requestDataFilterExpression_dataFilterExpression_Dimensions should be set to null
            if (requestDataFilterExpression_dataFilterExpression_DimensionsIsNull)
            {
                requestDataFilterExpression_dataFilterExpression_Dimensions = null;
            }
            if (requestDataFilterExpression_dataFilterExpression_Dimensions != null)
            {
                request.DataFilterExpression.Dimensions = requestDataFilterExpression_dataFilterExpression_Dimensions;
                requestDataFilterExpressionIsNull = false;
            }
            Amazon.Billing.Model.TagValues requestDataFilterExpression_dataFilterExpression_Tags = null;
            
             // populate Tags
            var requestDataFilterExpression_dataFilterExpression_TagsIsNull = true;
            requestDataFilterExpression_dataFilterExpression_Tags = new Amazon.Billing.Model.TagValues();
            System.String requestDataFilterExpression_dataFilterExpression_Tags_tags_Key = null;
            if (cmdletContext.Tags_Key != null)
            {
                requestDataFilterExpression_dataFilterExpression_Tags_tags_Key = cmdletContext.Tags_Key;
            }
            if (requestDataFilterExpression_dataFilterExpression_Tags_tags_Key != null)
            {
                requestDataFilterExpression_dataFilterExpression_Tags.Key = requestDataFilterExpression_dataFilterExpression_Tags_tags_Key;
                requestDataFilterExpression_dataFilterExpression_TagsIsNull = false;
            }
            List<System.String> requestDataFilterExpression_dataFilterExpression_Tags_tags_Value = null;
            if (cmdletContext.Tags_Value != null)
            {
                requestDataFilterExpression_dataFilterExpression_Tags_tags_Value = cmdletContext.Tags_Value;
            }
            if (requestDataFilterExpression_dataFilterExpression_Tags_tags_Value != null)
            {
                requestDataFilterExpression_dataFilterExpression_Tags.Values = requestDataFilterExpression_dataFilterExpression_Tags_tags_Value;
                requestDataFilterExpression_dataFilterExpression_TagsIsNull = false;
            }
             // determine if requestDataFilterExpression_dataFilterExpression_Tags should be set to null
            if (requestDataFilterExpression_dataFilterExpression_TagsIsNull)
            {
                requestDataFilterExpression_dataFilterExpression_Tags = null;
            }
            if (requestDataFilterExpression_dataFilterExpression_Tags != null)
            {
                request.DataFilterExpression.Tags = requestDataFilterExpression_dataFilterExpression_Tags;
                requestDataFilterExpressionIsNull = false;
            }
             // determine if request.DataFilterExpression should be set to null
            if (requestDataFilterExpressionIsNull)
            {
                request.DataFilterExpression = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Billing.Model.UpdateBillingViewResponse CallAWSServiceOperation(IAmazonBilling client, Amazon.Billing.Model.UpdateBillingViewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Billing", "UpdateBillingView");
            try
            {
                return client.UpdateBillingViewAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public Amazon.Billing.Dimension Dimensions_Key { get; set; }
            public List<System.String> Dimensions_Value { get; set; }
            public System.String Tags_Key { get; set; }
            public List<System.String> Tags_Value { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.Billing.Model.UpdateBillingViewResponse, UpdateAWSBBillingViewCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
