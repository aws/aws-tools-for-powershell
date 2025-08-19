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
using Amazon.DataZone;
using Amazon.DataZone.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Creates an account pool.
    /// </summary>
    [Cmdlet("New", "DZAccountPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.CreateAccountPoolResponse")]
    [AWSCmdlet("Calls the Amazon DataZone CreateAccountPool API operation.", Operation = new[] {"CreateAccountPool"}, SelectReturnType = typeof(Amazon.DataZone.Model.CreateAccountPoolResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.CreateAccountPoolResponse",
        "This cmdlet returns an Amazon.DataZone.Model.CreateAccountPoolResponse object containing multiple properties."
    )]
    public partial class NewDZAccountPoolCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountSource_Account
        /// <summary>
        /// <para>
        /// <para>The static list of accounts within an account pool.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountSource_Accounts")]
        public Amazon.DataZone.Model.AccountInfo[] AccountSource_Account { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the account pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the domain where the account pool is created.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter CustomAccountPoolHandler_LambdaExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that enables Amazon SageMaker Unified Studio to invoke the
        /// Amazon Web Services Lambda funtion if the account source is the custom account pool
        /// handler.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountSource_CustomAccountPoolHandler_LambdaExecutionRoleArn")]
        public System.String CustomAccountPoolHandler_LambdaExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter CustomAccountPoolHandler_LambdaFunctionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Web Services Lambda function for the custom Amazon Web Services
        /// Lambda handler.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountSource_CustomAccountPoolHandler_LambdaFunctionArn")]
        public System.String CustomAccountPoolHandler_LambdaFunctionArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the account pool.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ResolutionStrategy
        /// <summary>
        /// <para>
        /// <para>The mechanism used to resolve the account selection from the account pool.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DataZone.ResolutionStrategy")]
        public Amazon.DataZone.ResolutionStrategy ResolutionStrategy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.CreateAccountPoolResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.CreateAccountPoolResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DZAccountPool (CreateAccountPool)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.CreateAccountPoolResponse, NewDZAccountPoolCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountSource_Account != null)
            {
                context.AccountSource_Account = new List<Amazon.DataZone.Model.AccountInfo>(this.AccountSource_Account);
            }
            context.CustomAccountPoolHandler_LambdaExecutionRoleArn = this.CustomAccountPoolHandler_LambdaExecutionRoleArn;
            context.CustomAccountPoolHandler_LambdaFunctionArn = this.CustomAccountPoolHandler_LambdaFunctionArn;
            context.Description = this.Description;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResolutionStrategy = this.ResolutionStrategy;
            #if MODULAR
            if (this.ResolutionStrategy == null && ParameterWasBound(nameof(this.ResolutionStrategy)))
            {
                WriteWarning("You are passing $null as a value for parameter ResolutionStrategy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataZone.Model.CreateAccountPoolRequest();
            
            
             // populate AccountSource
            request.AccountSource = new Amazon.DataZone.Model.AccountSource();
            List<Amazon.DataZone.Model.AccountInfo> requestAccountSource_accountSource_Account = null;
            if (cmdletContext.AccountSource_Account != null)
            {
                requestAccountSource_accountSource_Account = cmdletContext.AccountSource_Account;
            }
            if (requestAccountSource_accountSource_Account != null)
            {
                request.AccountSource.Accounts = requestAccountSource_accountSource_Account;
            }
            Amazon.DataZone.Model.CustomAccountPoolHandler requestAccountSource_accountSource_CustomAccountPoolHandler = null;
            
             // populate CustomAccountPoolHandler
            var requestAccountSource_accountSource_CustomAccountPoolHandlerIsNull = true;
            requestAccountSource_accountSource_CustomAccountPoolHandler = new Amazon.DataZone.Model.CustomAccountPoolHandler();
            System.String requestAccountSource_accountSource_CustomAccountPoolHandler_customAccountPoolHandler_LambdaExecutionRoleArn = null;
            if (cmdletContext.CustomAccountPoolHandler_LambdaExecutionRoleArn != null)
            {
                requestAccountSource_accountSource_CustomAccountPoolHandler_customAccountPoolHandler_LambdaExecutionRoleArn = cmdletContext.CustomAccountPoolHandler_LambdaExecutionRoleArn;
            }
            if (requestAccountSource_accountSource_CustomAccountPoolHandler_customAccountPoolHandler_LambdaExecutionRoleArn != null)
            {
                requestAccountSource_accountSource_CustomAccountPoolHandler.LambdaExecutionRoleArn = requestAccountSource_accountSource_CustomAccountPoolHandler_customAccountPoolHandler_LambdaExecutionRoleArn;
                requestAccountSource_accountSource_CustomAccountPoolHandlerIsNull = false;
            }
            System.String requestAccountSource_accountSource_CustomAccountPoolHandler_customAccountPoolHandler_LambdaFunctionArn = null;
            if (cmdletContext.CustomAccountPoolHandler_LambdaFunctionArn != null)
            {
                requestAccountSource_accountSource_CustomAccountPoolHandler_customAccountPoolHandler_LambdaFunctionArn = cmdletContext.CustomAccountPoolHandler_LambdaFunctionArn;
            }
            if (requestAccountSource_accountSource_CustomAccountPoolHandler_customAccountPoolHandler_LambdaFunctionArn != null)
            {
                requestAccountSource_accountSource_CustomAccountPoolHandler.LambdaFunctionArn = requestAccountSource_accountSource_CustomAccountPoolHandler_customAccountPoolHandler_LambdaFunctionArn;
                requestAccountSource_accountSource_CustomAccountPoolHandlerIsNull = false;
            }
             // determine if requestAccountSource_accountSource_CustomAccountPoolHandler should be set to null
            if (requestAccountSource_accountSource_CustomAccountPoolHandlerIsNull)
            {
                requestAccountSource_accountSource_CustomAccountPoolHandler = null;
            }
            if (requestAccountSource_accountSource_CustomAccountPoolHandler != null)
            {
                request.AccountSource.CustomAccountPoolHandler = requestAccountSource_accountSource_CustomAccountPoolHandler;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ResolutionStrategy != null)
            {
                request.ResolutionStrategy = cmdletContext.ResolutionStrategy;
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
        
        private Amazon.DataZone.Model.CreateAccountPoolResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.CreateAccountPoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "CreateAccountPool");
            try
            {
                return client.CreateAccountPoolAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.DataZone.Model.AccountInfo> AccountSource_Account { get; set; }
            public System.String CustomAccountPoolHandler_LambdaExecutionRoleArn { get; set; }
            public System.String CustomAccountPoolHandler_LambdaFunctionArn { get; set; }
            public System.String Description { get; set; }
            public System.String DomainIdentifier { get; set; }
            public System.String Name { get; set; }
            public Amazon.DataZone.ResolutionStrategy ResolutionStrategy { get; set; }
            public System.Func<Amazon.DataZone.Model.CreateAccountPoolResponse, NewDZAccountPoolCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
