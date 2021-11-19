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
using Amazon.IoTTwinMaker;
using Amazon.IoTTwinMaker.Model;

namespace Amazon.PowerShell.Cmdlets.IOTTM
{
    /// <summary>
    /// Creates an entity.
    /// </summary>
    [Cmdlet("New", "IOTTMEntity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTTwinMaker.Model.CreateEntityResponse")]
    [AWSCmdlet("Calls the AWS IoT TwinMaker CreateEntity API operation.", Operation = new[] {"CreateEntity"}, SelectReturnType = typeof(Amazon.IoTTwinMaker.Model.CreateEntityResponse))]
    [AWSCmdletOutput("Amazon.IoTTwinMaker.Model.CreateEntityResponse",
        "This cmdlet returns an Amazon.IoTTwinMaker.Model.CreateEntityResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTTMEntityCmdlet : AmazonIoTTwinMakerClientCmdlet, IExecutor
    {
        
        #region Parameter Component
        /// <summary>
        /// <para>
        /// <para>An object that maps strings to the components in the entity. Each string in the mapping
        /// must be unique to this object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Components")]
        public System.Collections.Hashtable Component { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EntityId
        /// <summary>
        /// <para>
        /// <para>The ID of the entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityId { get; set; }
        #endregion
        
        #region Parameter EntityName
        /// <summary>
        /// <para>
        /// <para>The name of the entity.</para>
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
        public System.String EntityName { get; set; }
        #endregion
        
        #region Parameter ParentEntityId
        /// <summary>
        /// <para>
        /// <para>The ID of the entity's parent entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentEntityId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that you can use to manage the entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the workspace that contains the entity.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTTwinMaker.Model.CreateEntityResponse).
        /// Specifying the name of a property of type Amazon.IoTTwinMaker.Model.CreateEntityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EntityName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EntityName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EntityName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EntityName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTTMEntity (CreateEntity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTTwinMaker.Model.CreateEntityResponse, NewIOTTMEntityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EntityName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Component != null)
            {
                context.Component = new Dictionary<System.String, Amazon.IoTTwinMaker.Model.ComponentRequest>(StringComparer.Ordinal);
                foreach (var hashKey in this.Component.Keys)
                {
                    context.Component.Add((String)hashKey, (ComponentRequest)(this.Component[hashKey]));
                }
            }
            context.Description = this.Description;
            context.EntityId = this.EntityId;
            context.EntityName = this.EntityName;
            #if MODULAR
            if (this.EntityName == null && ParameterWasBound(nameof(this.EntityName)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParentEntityId = this.ParentEntityId;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.IoTTwinMaker.Model.CreateEntityRequest();
            
            if (cmdletContext.Component != null)
            {
                request.Components = cmdletContext.Component;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EntityId != null)
            {
                request.EntityId = cmdletContext.EntityId;
            }
            if (cmdletContext.EntityName != null)
            {
                request.EntityName = cmdletContext.EntityName;
            }
            if (cmdletContext.ParentEntityId != null)
            {
                request.ParentEntityId = cmdletContext.ParentEntityId;
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
        
        private Amazon.IoTTwinMaker.Model.CreateEntityResponse CallAWSServiceOperation(IAmazonIoTTwinMaker client, Amazon.IoTTwinMaker.Model.CreateEntityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT TwinMaker", "CreateEntity");
            try
            {
                #if DESKTOP
                return client.CreateEntity(request);
                #elif CORECLR
                return client.CreateEntityAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.IoTTwinMaker.Model.ComponentRequest> Component { get; set; }
            public System.String Description { get; set; }
            public System.String EntityId { get; set; }
            public System.String EntityName { get; set; }
            public System.String ParentEntityId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.IoTTwinMaker.Model.CreateEntityResponse, NewIOTTMEntityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
