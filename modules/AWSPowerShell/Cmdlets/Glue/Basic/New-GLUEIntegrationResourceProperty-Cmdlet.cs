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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// This API can be used for setting up the <c>ResourceProperty</c> of the Glue connection
    /// (for the source) or Glue database ARN (for the target). These properties can include
    /// the role to access the connection or database. To set both source and target properties
    /// the same API needs to be invoked with the Glue connection ARN as <c>ResourceArn</c>
    /// with <c>SourceProcessingProperties</c> and the Glue database ARN as <c>ResourceArn</c>
    /// with <c>TargetProcessingProperties</c> respectively.
    /// </summary>
    [Cmdlet("New", "GLUEIntegrationResourceProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.CreateIntegrationResourcePropertyResponse")]
    [AWSCmdlet("Calls the AWS Glue CreateIntegrationResourceProperty API operation.", Operation = new[] {"CreateIntegrationResourceProperty"}, SelectReturnType = typeof(Amazon.Glue.Model.CreateIntegrationResourcePropertyResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.CreateIntegrationResourcePropertyResponse",
        "This cmdlet returns an Amazon.Glue.Model.CreateIntegrationResourcePropertyResponse object containing multiple properties."
    )]
    public partial class NewGLUEIntegrationResourcePropertyCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TargetProcessingProperties_ConnectionName
        /// <summary>
        /// <para>
        /// <para>The Glue network connection to configure the Glue job running in the customer VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetProcessingProperties_ConnectionName { get; set; }
        #endregion
        
        #region Parameter TargetProcessingProperties_EventBusArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an Eventbridge event bus to receive the integration status notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetProcessingProperties_EventBusArn { get; set; }
        #endregion
        
        #region Parameter TargetProcessingProperties_KmsArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key used for encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetProcessingProperties_KmsArn { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The connection ARN of the source, or the database ARN of the target.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter SourceProcessingProperties_RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role to access the Glue connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceProcessingProperties_RoleArn { get; set; }
        #endregion
        
        #region Parameter TargetProcessingProperties_RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role to access the Glue database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetProcessingProperties_RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CreateIntegrationResourcePropertyResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.CreateIntegrationResourcePropertyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUEIntegrationResourceProperty (CreateIntegrationResourceProperty)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CreateIntegrationResourcePropertyResponse, NewGLUEIntegrationResourcePropertyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceProcessingProperties_RoleArn = this.SourceProcessingProperties_RoleArn;
            context.TargetProcessingProperties_ConnectionName = this.TargetProcessingProperties_ConnectionName;
            context.TargetProcessingProperties_EventBusArn = this.TargetProcessingProperties_EventBusArn;
            context.TargetProcessingProperties_KmsArn = this.TargetProcessingProperties_KmsArn;
            context.TargetProcessingProperties_RoleArn = this.TargetProcessingProperties_RoleArn;
            
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
            var request = new Amazon.Glue.Model.CreateIntegrationResourcePropertyRequest();
            
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
            }
            
             // populate SourceProcessingProperties
            var requestSourceProcessingPropertiesIsNull = true;
            request.SourceProcessingProperties = new Amazon.Glue.Model.SourceProcessingProperties();
            System.String requestSourceProcessingProperties_sourceProcessingProperties_RoleArn = null;
            if (cmdletContext.SourceProcessingProperties_RoleArn != null)
            {
                requestSourceProcessingProperties_sourceProcessingProperties_RoleArn = cmdletContext.SourceProcessingProperties_RoleArn;
            }
            if (requestSourceProcessingProperties_sourceProcessingProperties_RoleArn != null)
            {
                request.SourceProcessingProperties.RoleArn = requestSourceProcessingProperties_sourceProcessingProperties_RoleArn;
                requestSourceProcessingPropertiesIsNull = false;
            }
             // determine if request.SourceProcessingProperties should be set to null
            if (requestSourceProcessingPropertiesIsNull)
            {
                request.SourceProcessingProperties = null;
            }
            
             // populate TargetProcessingProperties
            var requestTargetProcessingPropertiesIsNull = true;
            request.TargetProcessingProperties = new Amazon.Glue.Model.TargetProcessingProperties();
            System.String requestTargetProcessingProperties_targetProcessingProperties_ConnectionName = null;
            if (cmdletContext.TargetProcessingProperties_ConnectionName != null)
            {
                requestTargetProcessingProperties_targetProcessingProperties_ConnectionName = cmdletContext.TargetProcessingProperties_ConnectionName;
            }
            if (requestTargetProcessingProperties_targetProcessingProperties_ConnectionName != null)
            {
                request.TargetProcessingProperties.ConnectionName = requestTargetProcessingProperties_targetProcessingProperties_ConnectionName;
                requestTargetProcessingPropertiesIsNull = false;
            }
            System.String requestTargetProcessingProperties_targetProcessingProperties_EventBusArn = null;
            if (cmdletContext.TargetProcessingProperties_EventBusArn != null)
            {
                requestTargetProcessingProperties_targetProcessingProperties_EventBusArn = cmdletContext.TargetProcessingProperties_EventBusArn;
            }
            if (requestTargetProcessingProperties_targetProcessingProperties_EventBusArn != null)
            {
                request.TargetProcessingProperties.EventBusArn = requestTargetProcessingProperties_targetProcessingProperties_EventBusArn;
                requestTargetProcessingPropertiesIsNull = false;
            }
            System.String requestTargetProcessingProperties_targetProcessingProperties_KmsArn = null;
            if (cmdletContext.TargetProcessingProperties_KmsArn != null)
            {
                requestTargetProcessingProperties_targetProcessingProperties_KmsArn = cmdletContext.TargetProcessingProperties_KmsArn;
            }
            if (requestTargetProcessingProperties_targetProcessingProperties_KmsArn != null)
            {
                request.TargetProcessingProperties.KmsArn = requestTargetProcessingProperties_targetProcessingProperties_KmsArn;
                requestTargetProcessingPropertiesIsNull = false;
            }
            System.String requestTargetProcessingProperties_targetProcessingProperties_RoleArn = null;
            if (cmdletContext.TargetProcessingProperties_RoleArn != null)
            {
                requestTargetProcessingProperties_targetProcessingProperties_RoleArn = cmdletContext.TargetProcessingProperties_RoleArn;
            }
            if (requestTargetProcessingProperties_targetProcessingProperties_RoleArn != null)
            {
                request.TargetProcessingProperties.RoleArn = requestTargetProcessingProperties_targetProcessingProperties_RoleArn;
                requestTargetProcessingPropertiesIsNull = false;
            }
             // determine if request.TargetProcessingProperties should be set to null
            if (requestTargetProcessingPropertiesIsNull)
            {
                request.TargetProcessingProperties = null;
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
        
        private Amazon.Glue.Model.CreateIntegrationResourcePropertyResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateIntegrationResourcePropertyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateIntegrationResourceProperty");
            try
            {
                return client.CreateIntegrationResourcePropertyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ResourceArn { get; set; }
            public System.String SourceProcessingProperties_RoleArn { get; set; }
            public System.String TargetProcessingProperties_ConnectionName { get; set; }
            public System.String TargetProcessingProperties_EventBusArn { get; set; }
            public System.String TargetProcessingProperties_KmsArn { get; set; }
            public System.String TargetProcessingProperties_RoleArn { get; set; }
            public System.Func<Amazon.Glue.Model.CreateIntegrationResourcePropertyResponse, NewGLUEIntegrationResourcePropertyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
