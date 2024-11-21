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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates a command. A command contains reusable configurations that can be applied
    /// before they are sent to the devices.
    /// </summary>
    [Cmdlet("New", "IOTCommand", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateCommandResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateCommand API operation.", Operation = new[] {"CreateCommand"}, SelectReturnType = typeof(Amazon.IoT.Model.CreateCommandResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateCommandResponse",
        "This cmdlet returns an Amazon.IoT.Model.CreateCommandResponse object containing multiple properties."
    )]
    public partial class NewIOTCommandCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CommandId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the command. We recommend using UUID. Alpha-numeric characters,
        /// hyphens, and underscores are valid for use here.</para>
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
        public System.String CommandId { get; set; }
        #endregion
        
        #region Parameter Payload_Content
        /// <summary>
        /// <para>
        /// <para>The static payload file for the command.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Payload_Content { get; set; }
        #endregion
        
        #region Parameter Payload_ContentType
        /// <summary>
        /// <para>
        /// <para>The content type that specifies the format type of the payload file. This field must
        /// use a type/subtype format, such as <c>application/json</c>. For information about
        /// various content types, see <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/MIME_types/Common_types">Common
        /// MIME types</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Payload_ContentType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A short text decription of the command.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The user-friendly name in the console for the command. This name doesn't have to be
        /// unique. You can update the user-friendly name after you define it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter MandatoryParameter
        /// <summary>
        /// <para>
        /// <para>A list of parameters that are required by the <c>StartCommandExecution</c> API. These
        /// parameters need to be specified only when using the <c>AWS-IoT-FleetWise</c> namespace.
        /// You can either specify them here or when running the command using the <c>StartCommandExecution</c>
        /// API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MandatoryParameters")]
        public Amazon.IoT.Model.CommandParameter[] MandatoryParameter { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the command. The MQTT reserved topics and validations will be used
        /// for command executions according to the namespace setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.CommandNamespace")]
        public Amazon.IoT.CommandNamespace Namespace { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role that allows access to create the command.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Name-value pairs that are used as metadata to manage a command.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoT.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreateCommandResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreateCommandResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CommandId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CommandId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CommandId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CommandId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTCommand (CreateCommand)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreateCommandResponse, NewIOTCommandCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CommandId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CommandId = this.CommandId;
            #if MODULAR
            if (this.CommandId == null && ParameterWasBound(nameof(this.CommandId)))
            {
                WriteWarning("You are passing $null as a value for parameter CommandId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            if (this.MandatoryParameter != null)
            {
                context.MandatoryParameter = new List<Amazon.IoT.Model.CommandParameter>(this.MandatoryParameter);
            }
            context.Namespace = this.Namespace;
            context.Payload_Content = this.Payload_Content;
            context.Payload_ContentType = this.Payload_ContentType;
            context.RoleArn = this.RoleArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoT.Model.Tag>(this.Tag);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Payload_ContentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.IoT.Model.CreateCommandRequest();
                
                if (cmdletContext.CommandId != null)
                {
                    request.CommandId = cmdletContext.CommandId;
                }
                if (cmdletContext.Description != null)
                {
                    request.Description = cmdletContext.Description;
                }
                if (cmdletContext.DisplayName != null)
                {
                    request.DisplayName = cmdletContext.DisplayName;
                }
                if (cmdletContext.MandatoryParameter != null)
                {
                    request.MandatoryParameters = cmdletContext.MandatoryParameter;
                }
                if (cmdletContext.Namespace != null)
                {
                    request.Namespace = cmdletContext.Namespace;
                }
                
                 // populate Payload
                var requestPayloadIsNull = true;
                request.Payload = new Amazon.IoT.Model.CommandPayload();
                System.IO.MemoryStream requestPayload_payload_Content = null;
                if (cmdletContext.Payload_Content != null)
                {
                    _Payload_ContentStream = new System.IO.MemoryStream(cmdletContext.Payload_Content);
                    requestPayload_payload_Content = _Payload_ContentStream;
                }
                if (requestPayload_payload_Content != null)
                {
                    request.Payload.Content = requestPayload_payload_Content;
                    requestPayloadIsNull = false;
                }
                System.String requestPayload_payload_ContentType = null;
                if (cmdletContext.Payload_ContentType != null)
                {
                    requestPayload_payload_ContentType = cmdletContext.Payload_ContentType;
                }
                if (requestPayload_payload_ContentType != null)
                {
                    request.Payload.ContentType = requestPayload_payload_ContentType;
                    requestPayloadIsNull = false;
                }
                 // determine if request.Payload should be set to null
                if (requestPayloadIsNull)
                {
                    request.Payload = null;
                }
                if (cmdletContext.RoleArn != null)
                {
                    request.RoleArn = cmdletContext.RoleArn;
                }
                if (cmdletContext.Tag != null)
                {
                    request.Tags = cmdletContext.Tag;
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
            finally
            {
                if( _Payload_ContentStream != null)
                {
                    _Payload_ContentStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.IoT.Model.CreateCommandResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateCommandRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateCommand");
            try
            {
                #if DESKTOP
                return client.CreateCommand(request);
                #elif CORECLR
                return client.CreateCommandAsync(request).GetAwaiter().GetResult();
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
            public System.String CommandId { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public List<Amazon.IoT.Model.CommandParameter> MandatoryParameter { get; set; }
            public Amazon.IoT.CommandNamespace Namespace { get; set; }
            public byte[] Payload_Content { get; set; }
            public System.String Payload_ContentType { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.IoT.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IoT.Model.CreateCommandResponse, NewIOTCommandCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
