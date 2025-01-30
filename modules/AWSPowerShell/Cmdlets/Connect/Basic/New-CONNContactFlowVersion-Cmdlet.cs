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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Publishes a new version of the flow provided. Versions are immutable and monotonically
    /// increasing. If the <c>FlowContentSha256</c> provided is different from the <c>FlowContentSha256</c>
    /// of the <c>$LATEST</c> published flow content, then an error is returned. This API
    /// only supports creating versions for flows of type <c>Campaign</c>.
    /// </summary>
    [Cmdlet("New", "CONNContactFlowVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.CreateContactFlowVersionResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service CreateContactFlowVersion API operation.", Operation = new[] {"CreateContactFlowVersion"}, SelectReturnType = typeof(Amazon.Connect.Model.CreateContactFlowVersionResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.CreateContactFlowVersionResponse",
        "This cmdlet returns an Amazon.Connect.Model.CreateContactFlowVersionResponse object containing multiple properties."
    )]
    public partial class NewCONNContactFlowVersionCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContactFlowId
        /// <summary>
        /// <para>
        /// <para>The identifier of the flow.</para>
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
        public System.String ContactFlowId { get; set; }
        #endregion
        
        #region Parameter ContactFlowVersion
        /// <summary>
        /// <para>
        /// <para>The identifier of the flow version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ContactFlowVersion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the flow version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FlowContentSha256
        /// <summary>
        /// <para>
        /// <para>Indicates the checksum value of the flow content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FlowContentSha256 { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter LastModifiedRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region where this resource was last modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LastModifiedRegion { get; set; }
        #endregion
        
        #region Parameter LastModifiedTime
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region where this resource was last modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? LastModifiedTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.CreateContactFlowVersionResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.CreateContactFlowVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ContactFlowId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ContactFlowId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ContactFlowId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContactFlowId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONNContactFlowVersion (CreateContactFlowVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.CreateContactFlowVersionResponse, NewCONNContactFlowVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ContactFlowId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContactFlowId = this.ContactFlowId;
            #if MODULAR
            if (this.ContactFlowId == null && ParameterWasBound(nameof(this.ContactFlowId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactFlowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContactFlowVersion = this.ContactFlowVersion;
            context.Description = this.Description;
            context.FlowContentSha256 = this.FlowContentSha256;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LastModifiedRegion = this.LastModifiedRegion;
            context.LastModifiedTime = this.LastModifiedTime;
            
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
            var request = new Amazon.Connect.Model.CreateContactFlowVersionRequest();
            
            if (cmdletContext.ContactFlowId != null)
            {
                request.ContactFlowId = cmdletContext.ContactFlowId;
            }
            if (cmdletContext.ContactFlowVersion != null)
            {
                request.ContactFlowVersion = cmdletContext.ContactFlowVersion.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FlowContentSha256 != null)
            {
                request.FlowContentSha256 = cmdletContext.FlowContentSha256;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.LastModifiedRegion != null)
            {
                request.LastModifiedRegion = cmdletContext.LastModifiedRegion;
            }
            if (cmdletContext.LastModifiedTime != null)
            {
                request.LastModifiedTime = cmdletContext.LastModifiedTime.Value;
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
        
        private Amazon.Connect.Model.CreateContactFlowVersionResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.CreateContactFlowVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "CreateContactFlowVersion");
            try
            {
                #if DESKTOP
                return client.CreateContactFlowVersion(request);
                #elif CORECLR
                return client.CreateContactFlowVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String ContactFlowId { get; set; }
            public System.Int64? ContactFlowVersion { get; set; }
            public System.String Description { get; set; }
            public System.String FlowContentSha256 { get; set; }
            public System.String InstanceId { get; set; }
            public System.String LastModifiedRegion { get; set; }
            public System.DateTime? LastModifiedTime { get; set; }
            public System.Func<Amazon.Connect.Model.CreateContactFlowVersionResponse, NewCONNContactFlowVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
