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
using Amazon.IoTTwinMaker;
using Amazon.IoTTwinMaker.Model;

namespace Amazon.PowerShell.Cmdlets.IOTTM
{
    /// <summary>
    /// Creates a scene.
    /// </summary>
    [Cmdlet("New", "IOTTMScene", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTTwinMaker.Model.CreateSceneResponse")]
    [AWSCmdlet("Calls the AWS IoT TwinMaker CreateScene API operation.", Operation = new[] {"CreateScene"}, SelectReturnType = typeof(Amazon.IoTTwinMaker.Model.CreateSceneResponse))]
    [AWSCmdletOutput("Amazon.IoTTwinMaker.Model.CreateSceneResponse",
        "This cmdlet returns an Amazon.IoTTwinMaker.Model.CreateSceneResponse object containing multiple properties."
    )]
    public partial class NewIOTTMSceneCmdlet : AmazonIoTTwinMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Capability
        /// <summary>
        /// <para>
        /// <para>A list of capabilities that the scene uses to render itself.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities")]
        public System.String[] Capability { get; set; }
        #endregion
        
        #region Parameter ContentLocation
        /// <summary>
        /// <para>
        /// <para>The relative path that specifies the location of the content definition file.</para>
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
        public System.String ContentLocation { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description for this scene.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter SceneId
        /// <summary>
        /// <para>
        /// <para>The ID of the scene.</para>
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
        public System.String SceneId { get; set; }
        #endregion
        
        #region Parameter SceneMetadata
        /// <summary>
        /// <para>
        /// <para>The request metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable SceneMetadata { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that you can use to manage the scene.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the workspace that contains the scene.</para>
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
        public System.String WorkspaceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTTwinMaker.Model.CreateSceneResponse).
        /// Specifying the name of a property of type Amazon.IoTTwinMaker.Model.CreateSceneResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SceneId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SceneId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SceneId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SceneId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTTMScene (CreateScene)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTTwinMaker.Model.CreateSceneResponse, NewIOTTMSceneCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SceneId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Capability != null)
            {
                context.Capability = new List<System.String>(this.Capability);
            }
            context.ContentLocation = this.ContentLocation;
            #if MODULAR
            if (this.ContentLocation == null && ParameterWasBound(nameof(this.ContentLocation)))
            {
                WriteWarning("You are passing $null as a value for parameter ContentLocation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.SceneId = this.SceneId;
            #if MODULAR
            if (this.SceneId == null && ParameterWasBound(nameof(this.SceneId)))
            {
                WriteWarning("You are passing $null as a value for parameter SceneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SceneMetadata != null)
            {
                context.SceneMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SceneMetadata.Keys)
                {
                    context.SceneMetadata.Add((String)hashKey, (System.String)(this.SceneMetadata[hashKey]));
                }
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.WorkspaceId = this.WorkspaceId;
            #if MODULAR
            if (this.WorkspaceId == null && ParameterWasBound(nameof(this.WorkspaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTTwinMaker.Model.CreateSceneRequest();
            
            if (cmdletContext.Capability != null)
            {
                request.Capabilities = cmdletContext.Capability;
            }
            if (cmdletContext.ContentLocation != null)
            {
                request.ContentLocation = cmdletContext.ContentLocation;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.SceneId != null)
            {
                request.SceneId = cmdletContext.SceneId;
            }
            if (cmdletContext.SceneMetadata != null)
            {
                request.SceneMetadata = cmdletContext.SceneMetadata;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.WorkspaceId != null)
            {
                request.WorkspaceId = cmdletContext.WorkspaceId;
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
        
        private Amazon.IoTTwinMaker.Model.CreateSceneResponse CallAWSServiceOperation(IAmazonIoTTwinMaker client, Amazon.IoTTwinMaker.Model.CreateSceneRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT TwinMaker", "CreateScene");
            try
            {
                #if DESKTOP
                return client.CreateScene(request);
                #elif CORECLR
                return client.CreateSceneAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Capability { get; set; }
            public System.String ContentLocation { get; set; }
            public System.String Description { get; set; }
            public System.String SceneId { get; set; }
            public Dictionary<System.String, System.String> SceneMetadata { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.IoTTwinMaker.Model.CreateSceneResponse, NewIOTTMSceneCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
