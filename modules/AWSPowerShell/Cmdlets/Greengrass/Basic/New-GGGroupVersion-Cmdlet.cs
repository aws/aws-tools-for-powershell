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
using Amazon.Greengrass;
using Amazon.Greengrass.Model;

namespace Amazon.PowerShell.Cmdlets.GG
{
    /// <summary>
    /// Creates a version of a group which has already been defined.
    /// </summary>
    [Cmdlet("New", "GGGroupVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Greengrass.Model.CreateGroupVersionResponse")]
    [AWSCmdlet("Calls the AWS Greengrass CreateGroupVersion API operation.", Operation = new[] {"CreateGroupVersion"}, SelectReturnType = typeof(Amazon.Greengrass.Model.CreateGroupVersionResponse))]
    [AWSCmdletOutput("Amazon.Greengrass.Model.CreateGroupVersionResponse",
        "This cmdlet returns an Amazon.Greengrass.Model.CreateGroupVersionResponse object containing multiple properties."
    )]
    public partial class NewGGGroupVersionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AmznClientToken
        /// <summary>
        /// <para>
        /// A client token used to correlate requests
        /// and responses.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmznClientToken { get; set; }
        #endregion
        
        #region Parameter ConnectorDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the connector
        /// definition version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter CoreDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the core definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CoreDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter DeviceDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the device definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter FunctionDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the function definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FunctionDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter GroupId
        /// <summary>
        /// <para>
        /// The ID of the Greengrass group.
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
        public System.String GroupId { get; set; }
        #endregion
        
        #region Parameter LoggerDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the logger definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggerDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter ResourceDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the resource definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter SubscriptionDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the subscription
        /// definition version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubscriptionDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Greengrass.Model.CreateGroupVersionResponse).
        /// Specifying the name of a property of type Amazon.Greengrass.Model.CreateGroupVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GroupId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGGroupVersion (CreateGroupVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Greengrass.Model.CreateGroupVersionResponse, NewGGGroupVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AmznClientToken = this.AmznClientToken;
            context.ConnectorDefinitionVersionArn = this.ConnectorDefinitionVersionArn;
            context.CoreDefinitionVersionArn = this.CoreDefinitionVersionArn;
            context.DeviceDefinitionVersionArn = this.DeviceDefinitionVersionArn;
            context.FunctionDefinitionVersionArn = this.FunctionDefinitionVersionArn;
            context.GroupId = this.GroupId;
            #if MODULAR
            if (this.GroupId == null && ParameterWasBound(nameof(this.GroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoggerDefinitionVersionArn = this.LoggerDefinitionVersionArn;
            context.ResourceDefinitionVersionArn = this.ResourceDefinitionVersionArn;
            context.SubscriptionDefinitionVersionArn = this.SubscriptionDefinitionVersionArn;
            
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
            var request = new Amazon.Greengrass.Model.CreateGroupVersionRequest();
            
            if (cmdletContext.AmznClientToken != null)
            {
                request.AmznClientToken = cmdletContext.AmznClientToken;
            }
            if (cmdletContext.ConnectorDefinitionVersionArn != null)
            {
                request.ConnectorDefinitionVersionArn = cmdletContext.ConnectorDefinitionVersionArn;
            }
            if (cmdletContext.CoreDefinitionVersionArn != null)
            {
                request.CoreDefinitionVersionArn = cmdletContext.CoreDefinitionVersionArn;
            }
            if (cmdletContext.DeviceDefinitionVersionArn != null)
            {
                request.DeviceDefinitionVersionArn = cmdletContext.DeviceDefinitionVersionArn;
            }
            if (cmdletContext.FunctionDefinitionVersionArn != null)
            {
                request.FunctionDefinitionVersionArn = cmdletContext.FunctionDefinitionVersionArn;
            }
            if (cmdletContext.GroupId != null)
            {
                request.GroupId = cmdletContext.GroupId;
            }
            if (cmdletContext.LoggerDefinitionVersionArn != null)
            {
                request.LoggerDefinitionVersionArn = cmdletContext.LoggerDefinitionVersionArn;
            }
            if (cmdletContext.ResourceDefinitionVersionArn != null)
            {
                request.ResourceDefinitionVersionArn = cmdletContext.ResourceDefinitionVersionArn;
            }
            if (cmdletContext.SubscriptionDefinitionVersionArn != null)
            {
                request.SubscriptionDefinitionVersionArn = cmdletContext.SubscriptionDefinitionVersionArn;
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
        
        private Amazon.Greengrass.Model.CreateGroupVersionResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.CreateGroupVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "CreateGroupVersion");
            try
            {
                #if DESKTOP
                return client.CreateGroupVersion(request);
                #elif CORECLR
                return client.CreateGroupVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String AmznClientToken { get; set; }
            public System.String ConnectorDefinitionVersionArn { get; set; }
            public System.String CoreDefinitionVersionArn { get; set; }
            public System.String DeviceDefinitionVersionArn { get; set; }
            public System.String FunctionDefinitionVersionArn { get; set; }
            public System.String GroupId { get; set; }
            public System.String LoggerDefinitionVersionArn { get; set; }
            public System.String ResourceDefinitionVersionArn { get; set; }
            public System.String SubscriptionDefinitionVersionArn { get; set; }
            public System.Func<Amazon.Greengrass.Model.CreateGroupVersionResponse, NewGGGroupVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
