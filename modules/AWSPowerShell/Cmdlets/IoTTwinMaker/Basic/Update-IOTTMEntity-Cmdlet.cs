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
    /// Updates an entity.
    /// </summary>
    [Cmdlet("Update", "IOTTMEntity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTTwinMaker.Model.UpdateEntityResponse")]
    [AWSCmdlet("Calls the AWS IoT TwinMaker UpdateEntity API operation.", Operation = new[] {"UpdateEntity"}, SelectReturnType = typeof(Amazon.IoTTwinMaker.Model.UpdateEntityResponse))]
    [AWSCmdletOutput("Amazon.IoTTwinMaker.Model.UpdateEntityResponse",
        "This cmdlet returns an Amazon.IoTTwinMaker.Model.UpdateEntityResponse object containing multiple properties."
    )]
    public partial class UpdateIOTTMEntityCmdlet : AmazonIoTTwinMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ComponentUpdate
        /// <summary>
        /// <para>
        /// <para>An object that maps strings to the component updates in the request. Each string in
        /// the mapping must be unique to this object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComponentUpdates")]
        public System.Collections.Hashtable ComponentUpdate { get; set; }
        #endregion
        
        #region Parameter CompositeComponentUpdate
        /// <summary>
        /// <para>
        /// <para>This is an object that maps strings to <c>compositeComponent</c> updates in the request.
        /// Each key of the map represents the <c>componentPath</c> of the <c>compositeComponent</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CompositeComponentUpdates")]
        public System.Collections.Hashtable CompositeComponentUpdate { get; set; }
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
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String EntityId { get; set; }
        #endregion
        
        #region Parameter EntityName
        /// <summary>
        /// <para>
        /// <para>The name of the entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityName { get; set; }
        #endregion
        
        #region Parameter ParentEntityUpdate_ParentEntityId
        /// <summary>
        /// <para>
        /// <para>The ID of the parent entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentEntityUpdate_ParentEntityId { get; set; }
        #endregion
        
        #region Parameter ParentEntityUpdate_UpdateType
        /// <summary>
        /// <para>
        /// <para>The type of the update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTTwinMaker.ParentEntityUpdateType")]
        public Amazon.IoTTwinMaker.ParentEntityUpdateType ParentEntityUpdate_UpdateType { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTTwinMaker.Model.UpdateEntityResponse).
        /// Specifying the name of a property of type Amazon.IoTTwinMaker.Model.UpdateEntityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EntityId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EntityId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EntityId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EntityId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTTMEntity (UpdateEntity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTTwinMaker.Model.UpdateEntityResponse, UpdateIOTTMEntityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EntityId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ComponentUpdate != null)
            {
                context.ComponentUpdate = new Dictionary<System.String, Amazon.IoTTwinMaker.Model.ComponentUpdateRequest>(StringComparer.Ordinal);
                foreach (var hashKey in this.ComponentUpdate.Keys)
                {
                    context.ComponentUpdate.Add((String)hashKey, (Amazon.IoTTwinMaker.Model.ComponentUpdateRequest)(this.ComponentUpdate[hashKey]));
                }
            }
            if (this.CompositeComponentUpdate != null)
            {
                context.CompositeComponentUpdate = new Dictionary<System.String, Amazon.IoTTwinMaker.Model.CompositeComponentUpdateRequest>(StringComparer.Ordinal);
                foreach (var hashKey in this.CompositeComponentUpdate.Keys)
                {
                    context.CompositeComponentUpdate.Add((String)hashKey, (Amazon.IoTTwinMaker.Model.CompositeComponentUpdateRequest)(this.CompositeComponentUpdate[hashKey]));
                }
            }
            context.Description = this.Description;
            context.EntityId = this.EntityId;
            #if MODULAR
            if (this.EntityId == null && ParameterWasBound(nameof(this.EntityId)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EntityName = this.EntityName;
            context.ParentEntityUpdate_ParentEntityId = this.ParentEntityUpdate_ParentEntityId;
            context.ParentEntityUpdate_UpdateType = this.ParentEntityUpdate_UpdateType;
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
            var request = new Amazon.IoTTwinMaker.Model.UpdateEntityRequest();
            
            if (cmdletContext.ComponentUpdate != null)
            {
                request.ComponentUpdates = cmdletContext.ComponentUpdate;
            }
            if (cmdletContext.CompositeComponentUpdate != null)
            {
                request.CompositeComponentUpdates = cmdletContext.CompositeComponentUpdate;
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
            
             // populate ParentEntityUpdate
            var requestParentEntityUpdateIsNull = true;
            request.ParentEntityUpdate = new Amazon.IoTTwinMaker.Model.ParentEntityUpdateRequest();
            System.String requestParentEntityUpdate_parentEntityUpdate_ParentEntityId = null;
            if (cmdletContext.ParentEntityUpdate_ParentEntityId != null)
            {
                requestParentEntityUpdate_parentEntityUpdate_ParentEntityId = cmdletContext.ParentEntityUpdate_ParentEntityId;
            }
            if (requestParentEntityUpdate_parentEntityUpdate_ParentEntityId != null)
            {
                request.ParentEntityUpdate.ParentEntityId = requestParentEntityUpdate_parentEntityUpdate_ParentEntityId;
                requestParentEntityUpdateIsNull = false;
            }
            Amazon.IoTTwinMaker.ParentEntityUpdateType requestParentEntityUpdate_parentEntityUpdate_UpdateType = null;
            if (cmdletContext.ParentEntityUpdate_UpdateType != null)
            {
                requestParentEntityUpdate_parentEntityUpdate_UpdateType = cmdletContext.ParentEntityUpdate_UpdateType;
            }
            if (requestParentEntityUpdate_parentEntityUpdate_UpdateType != null)
            {
                request.ParentEntityUpdate.UpdateType = requestParentEntityUpdate_parentEntityUpdate_UpdateType;
                requestParentEntityUpdateIsNull = false;
            }
             // determine if request.ParentEntityUpdate should be set to null
            if (requestParentEntityUpdateIsNull)
            {
                request.ParentEntityUpdate = null;
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
        
        private Amazon.IoTTwinMaker.Model.UpdateEntityResponse CallAWSServiceOperation(IAmazonIoTTwinMaker client, Amazon.IoTTwinMaker.Model.UpdateEntityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT TwinMaker", "UpdateEntity");
            try
            {
                #if DESKTOP
                return client.UpdateEntity(request);
                #elif CORECLR
                return client.UpdateEntityAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.IoTTwinMaker.Model.ComponentUpdateRequest> ComponentUpdate { get; set; }
            public Dictionary<System.String, Amazon.IoTTwinMaker.Model.CompositeComponentUpdateRequest> CompositeComponentUpdate { get; set; }
            public System.String Description { get; set; }
            public System.String EntityId { get; set; }
            public System.String EntityName { get; set; }
            public System.String ParentEntityUpdate_ParentEntityId { get; set; }
            public Amazon.IoTTwinMaker.ParentEntityUpdateType ParentEntityUpdate_UpdateType { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.IoTTwinMaker.Model.UpdateEntityResponse, UpdateIOTTMEntityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
