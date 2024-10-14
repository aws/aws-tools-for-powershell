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
using Amazon.CloudSearch;
using Amazon.CloudSearch.Model;

namespace Amazon.PowerShell.Cmdlets.CS
{
    /// <summary>
    /// Configures an <c><a>Expression</a></c> for the search domain. Used to create new expressions
    /// and modify existing ones. If the expression exists, the new configuration replaces
    /// the old one. For more information, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/configuring-expressions.html" target="_blank">Configuring Expressions</a> in the <i>Amazon CloudSearch Developer
    /// Guide</i>.
    /// </summary>
    [Cmdlet("Set", "CSExpression", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudSearch.Model.ExpressionStatus")]
    [AWSCmdlet("Calls the Amazon CloudSearch DefineExpression API operation.", Operation = new[] {"DefineExpression"}, SelectReturnType = typeof(Amazon.CloudSearch.Model.DefineExpressionResponse))]
    [AWSCmdletOutput("Amazon.CloudSearch.Model.ExpressionStatus or Amazon.CloudSearch.Model.DefineExpressionResponse",
        "This cmdlet returns an Amazon.CloudSearch.Model.ExpressionStatus object.",
        "The service call response (type Amazon.CloudSearch.Model.DefineExpressionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetCSExpressionCmdlet : AmazonCloudSearchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter Expression_ExpressionName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String Expression_ExpressionName { get; set; }
        #endregion
        
        #region Parameter Expression_ExpressionValue
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String Expression_ExpressionValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Expression'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudSearch.Model.DefineExpressionResponse).
        /// Specifying the name of a property of type Amazon.CloudSearch.Model.DefineExpressionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Expression";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CSExpression (DefineExpression)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudSearch.Model.DefineExpressionResponse, SetCSExpressionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Expression_ExpressionName = this.Expression_ExpressionName;
            #if MODULAR
            if (this.Expression_ExpressionName == null && ParameterWasBound(nameof(this.Expression_ExpressionName)))
            {
                WriteWarning("You are passing $null as a value for parameter Expression_ExpressionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Expression_ExpressionValue = this.Expression_ExpressionValue;
            #if MODULAR
            if (this.Expression_ExpressionValue == null && ParameterWasBound(nameof(this.Expression_ExpressionValue)))
            {
                WriteWarning("You are passing $null as a value for parameter Expression_ExpressionValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudSearch.Model.DefineExpressionRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate Expression
            var requestExpressionIsNull = true;
            request.Expression = new Amazon.CloudSearch.Model.Expression();
            System.String requestExpression_expression_ExpressionName = null;
            if (cmdletContext.Expression_ExpressionName != null)
            {
                requestExpression_expression_ExpressionName = cmdletContext.Expression_ExpressionName;
            }
            if (requestExpression_expression_ExpressionName != null)
            {
                request.Expression.ExpressionName = requestExpression_expression_ExpressionName;
                requestExpressionIsNull = false;
            }
            System.String requestExpression_expression_ExpressionValue = null;
            if (cmdletContext.Expression_ExpressionValue != null)
            {
                requestExpression_expression_ExpressionValue = cmdletContext.Expression_ExpressionValue;
            }
            if (requestExpression_expression_ExpressionValue != null)
            {
                request.Expression.ExpressionValue = requestExpression_expression_ExpressionValue;
                requestExpressionIsNull = false;
            }
             // determine if request.Expression should be set to null
            if (requestExpressionIsNull)
            {
                request.Expression = null;
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
        
        private Amazon.CloudSearch.Model.DefineExpressionResponse CallAWSServiceOperation(IAmazonCloudSearch client, Amazon.CloudSearch.Model.DefineExpressionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudSearch", "DefineExpression");
            try
            {
                #if DESKTOP
                return client.DefineExpression(request);
                #elif CORECLR
                return client.DefineExpressionAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public System.String Expression_ExpressionName { get; set; }
            public System.String Expression_ExpressionValue { get; set; }
            public System.Func<Amazon.CloudSearch.Model.DefineExpressionResponse, SetCSExpressionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Expression;
        }
        
    }
}
