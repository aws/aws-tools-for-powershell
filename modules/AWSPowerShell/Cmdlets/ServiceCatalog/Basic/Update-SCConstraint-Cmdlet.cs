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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Updates the specified constraint.
    /// </summary>
    [Cmdlet("Update", "SCConstraint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.UpdateConstraintResponse")]
    [AWSCmdlet("Calls the AWS Service Catalog UpdateConstraint API operation.", Operation = new[] {"UpdateConstraint"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.UpdateConstraintResponse))]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.UpdateConstraintResponse",
        "This cmdlet returns an Amazon.ServiceCatalog.Model.UpdateConstraintResponse object containing multiple properties."
    )]
    public partial class UpdateSCConstraintCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><c>jp</c> - Japanese</para></li><li><para><c>zh</c> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description of the constraint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The identifier of the constraint.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The constraint parameters, in JSON format. The syntax depends on the constraint type
        /// as follows:</para><dl><dt>LAUNCH</dt><dd><para>You are required to specify either the <c>RoleArn</c> or the <c>LocalRoleName</c>
        /// but can't use both.</para><para>Specify the <c>RoleArn</c> property as follows:</para><para><c>{"RoleArn" : "arn:aws:iam::123456789012:role/LaunchRole"}</c></para><para>Specify the <c>LocalRoleName</c> property as follows:</para><para><c>{"LocalRoleName": "SCBasicLaunchRole"}</c></para><para>If you specify the <c>LocalRoleName</c> property, when an account uses the launch
        /// constraint, the IAM role with that name in the account will be used. This allows launch-role
        /// constraints to be account-agnostic so the administrator can create fewer resources
        /// per shared account.</para><note><para>The given role name must exist in the account used to create the launch constraint
        /// and the account of the user who launches a product with this launch constraint.</para></note><para>You cannot have both a <c>LAUNCH</c> and a <c>STACKSET</c> constraint.</para><para>You also cannot have more than one <c>LAUNCH</c> constraint on a product and portfolio.</para></dd><dt>NOTIFICATION</dt><dd><para>Specify the <c>NotificationArns</c> property as follows:</para><para><c>{"NotificationArns" : ["arn:aws:sns:us-east-1:123456789012:Topic"]}</c></para></dd><dt>RESOURCE_UPDATE</dt><dd><para>Specify the <c>TagUpdatesOnProvisionedProduct</c> property as follows:</para><para><c>{"Version":"2.0","Properties":{"TagUpdateOnProvisionedProduct":"String"}}</c></para><para>The <c>TagUpdatesOnProvisionedProduct</c> property accepts a string value of <c>ALLOWED</c>
        /// or <c>NOT_ALLOWED</c>.</para></dd><dt>STACKSET</dt><dd><para>Specify the <c>Parameters</c> property as follows:</para><para><c>{"Version": "String", "Properties": {"AccountList": [ "String" ], "RegionList":
        /// [ "String" ], "AdminRole": "String", "ExecutionRole": "String"}}</c></para><para>You cannot have both a <c>LAUNCH</c> and a <c>STACKSET</c> constraint.</para><para>You also cannot have more than one <c>STACKSET</c> constraint on a product and portfolio.</para><para>Products with a <c>STACKSET</c> constraint will launch an CloudFormation stack set.</para></dd><dt>TEMPLATE</dt><dd><para>Specify the <c>Rules</c> property. For more information, see <a href="http://docs.aws.amazon.com/servicecatalog/latest/adminguide/reference-template_constraint_rules.html">Template
        /// Constraint Rules</a>.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.String Parameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.UpdateConstraintResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.UpdateConstraintResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SCConstraint (UpdateConstraint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.UpdateConstraintResponse, UpdateSCConstraintCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptLanguage = this.AcceptLanguage;
            context.Description = this.Description;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Parameter = this.Parameter;
            
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
            var request = new Amazon.ServiceCatalog.Model.UpdateConstraintRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
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
        
        private Amazon.ServiceCatalog.Model.UpdateConstraintResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.UpdateConstraintRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "UpdateConstraint");
            try
            {
                #if DESKTOP
                return client.UpdateConstraint(request);
                #elif CORECLR
                return client.UpdateConstraintAsync(request).GetAwaiter().GetResult();
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
            public System.String AcceptLanguage { get; set; }
            public System.String Description { get; set; }
            public System.String Id { get; set; }
            public System.String Parameter { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.UpdateConstraintResponse, UpdateSCConstraintCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
