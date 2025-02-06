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
    /// Creates a component type.
    /// </summary>
    [Cmdlet("New", "IOTTMComponentType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTTwinMaker.Model.CreateComponentTypeResponse")]
    [AWSCmdlet("Calls the AWS IoT TwinMaker CreateComponentType API operation.", Operation = new[] {"CreateComponentType"}, SelectReturnType = typeof(Amazon.IoTTwinMaker.Model.CreateComponentTypeResponse))]
    [AWSCmdletOutput("Amazon.IoTTwinMaker.Model.CreateComponentTypeResponse",
        "This cmdlet returns an Amazon.IoTTwinMaker.Model.CreateComponentTypeResponse object containing multiple properties."
    )]
    public partial class NewIOTTMComponentTypeCmdlet : AmazonIoTTwinMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ComponentTypeId
        /// <summary>
        /// <para>
        /// <para>The ID of the component type.</para>
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
        public System.String ComponentTypeId { get; set; }
        #endregion
        
        #region Parameter ComponentTypeName
        /// <summary>
        /// <para>
        /// <para>A friendly name for the component type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComponentTypeName { get; set; }
        #endregion
        
        #region Parameter CompositeComponentType
        /// <summary>
        /// <para>
        /// <para>This is an object that maps strings to <c>compositeComponentTypes</c> of the <c>componentType</c>.
        /// <c>CompositeComponentType</c> is referenced by <c>componentTypeId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CompositeComponentTypes")]
        public System.Collections.Hashtable CompositeComponentType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the component type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExtendsFrom
        /// <summary>
        /// <para>
        /// <para>Specifies the parent component type to extend.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ExtendsFrom { get; set; }
        #endregion
        
        #region Parameter Function
        /// <summary>
        /// <para>
        /// <para>An object that maps strings to the functions in the component type. Each string in
        /// the mapping must be unique to this object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Functions")]
        public System.Collections.Hashtable Function { get; set; }
        #endregion
        
        #region Parameter IsSingleton
        /// <summary>
        /// <para>
        /// <para>A Boolean value that specifies whether an entity can have more than one component
        /// of this type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsSingleton { get; set; }
        #endregion
        
        #region Parameter PropertyDefinition
        /// <summary>
        /// <para>
        /// <para>An object that maps strings to the property definitions in the component type. Each
        /// string in the mapping must be unique to this object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropertyDefinitions")]
        public System.Collections.Hashtable PropertyDefinition { get; set; }
        #endregion
        
        #region Parameter PropertyGroup
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropertyGroups")]
        public System.Collections.Hashtable PropertyGroup { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that you can use to manage the component type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the workspace that contains the component type.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTTwinMaker.Model.CreateComponentTypeResponse).
        /// Specifying the name of a property of type Amazon.IoTTwinMaker.Model.CreateComponentTypeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ComponentTypeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTTMComponentType (CreateComponentType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTTwinMaker.Model.CreateComponentTypeResponse, NewIOTTMComponentTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ComponentTypeId = this.ComponentTypeId;
            #if MODULAR
            if (this.ComponentTypeId == null && ParameterWasBound(nameof(this.ComponentTypeId)))
            {
                WriteWarning("You are passing $null as a value for parameter ComponentTypeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComponentTypeName = this.ComponentTypeName;
            if (this.CompositeComponentType != null)
            {
                context.CompositeComponentType = new Dictionary<System.String, Amazon.IoTTwinMaker.Model.CompositeComponentTypeRequest>(StringComparer.Ordinal);
                foreach (var hashKey in this.CompositeComponentType.Keys)
                {
                    context.CompositeComponentType.Add((String)hashKey, (Amazon.IoTTwinMaker.Model.CompositeComponentTypeRequest)(this.CompositeComponentType[hashKey]));
                }
            }
            context.Description = this.Description;
            if (this.ExtendsFrom != null)
            {
                context.ExtendsFrom = new List<System.String>(this.ExtendsFrom);
            }
            if (this.Function != null)
            {
                context.Function = new Dictionary<System.String, Amazon.IoTTwinMaker.Model.FunctionRequest>(StringComparer.Ordinal);
                foreach (var hashKey in this.Function.Keys)
                {
                    context.Function.Add((String)hashKey, (Amazon.IoTTwinMaker.Model.FunctionRequest)(this.Function[hashKey]));
                }
            }
            context.IsSingleton = this.IsSingleton;
            if (this.PropertyDefinition != null)
            {
                context.PropertyDefinition = new Dictionary<System.String, Amazon.IoTTwinMaker.Model.PropertyDefinitionRequest>(StringComparer.Ordinal);
                foreach (var hashKey in this.PropertyDefinition.Keys)
                {
                    context.PropertyDefinition.Add((String)hashKey, (Amazon.IoTTwinMaker.Model.PropertyDefinitionRequest)(this.PropertyDefinition[hashKey]));
                }
            }
            if (this.PropertyGroup != null)
            {
                context.PropertyGroup = new Dictionary<System.String, Amazon.IoTTwinMaker.Model.PropertyGroupRequest>(StringComparer.Ordinal);
                foreach (var hashKey in this.PropertyGroup.Keys)
                {
                    context.PropertyGroup.Add((String)hashKey, (Amazon.IoTTwinMaker.Model.PropertyGroupRequest)(this.PropertyGroup[hashKey]));
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
            var request = new Amazon.IoTTwinMaker.Model.CreateComponentTypeRequest();
            
            if (cmdletContext.ComponentTypeId != null)
            {
                request.ComponentTypeId = cmdletContext.ComponentTypeId;
            }
            if (cmdletContext.ComponentTypeName != null)
            {
                request.ComponentTypeName = cmdletContext.ComponentTypeName;
            }
            if (cmdletContext.CompositeComponentType != null)
            {
                request.CompositeComponentTypes = cmdletContext.CompositeComponentType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExtendsFrom != null)
            {
                request.ExtendsFrom = cmdletContext.ExtendsFrom;
            }
            if (cmdletContext.Function != null)
            {
                request.Functions = cmdletContext.Function;
            }
            if (cmdletContext.IsSingleton != null)
            {
                request.IsSingleton = cmdletContext.IsSingleton.Value;
            }
            if (cmdletContext.PropertyDefinition != null)
            {
                request.PropertyDefinitions = cmdletContext.PropertyDefinition;
            }
            if (cmdletContext.PropertyGroup != null)
            {
                request.PropertyGroups = cmdletContext.PropertyGroup;
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
        
        private Amazon.IoTTwinMaker.Model.CreateComponentTypeResponse CallAWSServiceOperation(IAmazonIoTTwinMaker client, Amazon.IoTTwinMaker.Model.CreateComponentTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT TwinMaker", "CreateComponentType");
            try
            {
                #if DESKTOP
                return client.CreateComponentType(request);
                #elif CORECLR
                return client.CreateComponentTypeAsync(request).GetAwaiter().GetResult();
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
            public System.String ComponentTypeId { get; set; }
            public System.String ComponentTypeName { get; set; }
            public Dictionary<System.String, Amazon.IoTTwinMaker.Model.CompositeComponentTypeRequest> CompositeComponentType { get; set; }
            public System.String Description { get; set; }
            public List<System.String> ExtendsFrom { get; set; }
            public Dictionary<System.String, Amazon.IoTTwinMaker.Model.FunctionRequest> Function { get; set; }
            public System.Boolean? IsSingleton { get; set; }
            public Dictionary<System.String, Amazon.IoTTwinMaker.Model.PropertyDefinitionRequest> PropertyDefinition { get; set; }
            public Dictionary<System.String, Amazon.IoTTwinMaker.Model.PropertyGroupRequest> PropertyGroup { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.IoTTwinMaker.Model.CreateComponentTypeResponse, NewIOTTMComponentTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
