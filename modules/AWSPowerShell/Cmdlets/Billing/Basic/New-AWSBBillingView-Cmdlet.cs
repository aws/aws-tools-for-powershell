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
using Amazon.Billing;
using Amazon.Billing.Model;

namespace Amazon.PowerShell.Cmdlets.AWSB
{
    /// <summary>
    /// Creates a billing view with the specified billing view attributes.
    /// </summary>
    [Cmdlet("New", "AWSBBillingView", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Billing.Model.CreateBillingViewResponse")]
    [AWSCmdlet("Calls the AWS Billing CreateBillingView API operation.", Operation = new[] {"CreateBillingView"}, SelectReturnType = typeof(Amazon.Billing.Model.CreateBillingViewResponse))]
    [AWSCmdletOutput("Amazon.Billing.Model.CreateBillingViewResponse",
        "This cmdlet returns an Amazon.Billing.Model.CreateBillingViewResponse object containing multiple properties."
    )]
    public partial class NewAWSBBillingViewCmdlet : AmazonBillingClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ResourceTag
        /// <summary>
        /// <para>
        /// <para>A list of key value map specifying tags associated to the billing view being created.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTags")]
        public Amazon.Billing.Model.ResourceTag[] ResourceTag { get; set; }
        #endregion
        
        #region Parameter SourceView
        /// <summary>
        /// <para>
        /// <para>A list of billing views used as the data source for the custom billing view.</para>
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
        [Alias("SourceViews")]
        public System.String[] SourceView { get; set; }
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier you specify to ensure idempotency of the request.
        /// Idempotency ensures that an API request completes no more than one time. If the original
        /// request completes successfully, any subsequent retries complete successfully without
        /// performing any further actions with an idempotent request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Billing.Model.CreateBillingViewResponse).
        /// Specifying the name of a property of type Amazon.Billing.Model.CreateBillingViewResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AWSBBillingView (CreateBillingView)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Billing.Model.CreateBillingViewResponse, NewAWSBBillingViewCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
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
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceTag != null)
            {
                context.ResourceTag = new List<Amazon.Billing.Model.ResourceTag>(this.ResourceTag);
            }
            if (this.SourceView != null)
            {
                context.SourceView = new List<System.String>(this.SourceView);
            }
            #if MODULAR
            if (this.SourceView == null && ParameterWasBound(nameof(this.SourceView)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceView which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Billing.Model.CreateBillingViewRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
            if (cmdletContext.ResourceTag != null)
            {
                request.ResourceTags = cmdletContext.ResourceTag;
            }
            if (cmdletContext.SourceView != null)
            {
                request.SourceViews = cmdletContext.SourceView;
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
        
        private Amazon.Billing.Model.CreateBillingViewResponse CallAWSServiceOperation(IAmazonBilling client, Amazon.Billing.Model.CreateBillingViewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Billing", "CreateBillingView");
            try
            {
                #if DESKTOP
                return client.CreateBillingView(request);
                #elif CORECLR
                return client.CreateBillingViewAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Amazon.Billing.Dimension Dimensions_Key { get; set; }
            public List<System.String> Dimensions_Value { get; set; }
            public System.String Tags_Key { get; set; }
            public List<System.String> Tags_Value { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.Billing.Model.ResourceTag> ResourceTag { get; set; }
            public List<System.String> SourceView { get; set; }
            public System.Func<Amazon.Billing.Model.CreateBillingViewResponse, NewAWSBBillingViewCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
