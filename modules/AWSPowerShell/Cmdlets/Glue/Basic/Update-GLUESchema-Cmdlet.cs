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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Updates the description, compatibility setting, or version checkpoint for a schema
    /// set.
    /// 
    ///  
    /// <para>
    /// For updating the compatibility setting, the call will not validate compatibility for
    /// the entire set of schema versions with the new compatibility setting. If the value
    /// for <c>Compatibility</c> is provided, the <c>VersionNumber</c> (a checkpoint) is also
    /// required. The API will validate the checkpoint version number for consistency.
    /// </para><para>
    /// If the value for the <c>VersionNumber</c> (checkpoint) is provided, <c>Compatibility</c>
    /// is optional and this can be used to set/reset a checkpoint for the schema.
    /// </para><para>
    /// This update will happen only if the schema is in the AVAILABLE state.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "GLUESchema", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.UpdateSchemaResponse")]
    [AWSCmdlet("Calls the AWS Glue UpdateSchema API operation.", Operation = new[] {"UpdateSchema"}, SelectReturnType = typeof(Amazon.Glue.Model.UpdateSchemaResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.UpdateSchemaResponse",
        "This cmdlet returns an Amazon.Glue.Model.UpdateSchemaResponse object containing multiple properties."
    )]
    public partial class UpdateGLUESchemaCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Compatibility
        /// <summary>
        /// <para>
        /// <para>The new compatibility setting for the schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.Compatibility")]
        public Amazon.Glue.Compatibility Compatibility { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The new description for the schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter SchemaVersionNumber_LatestVersion
        /// <summary>
        /// <para>
        /// <para>The latest version available for the schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SchemaVersionNumber_LatestVersion { get; set; }
        #endregion
        
        #region Parameter SchemaId_RegistryName
        /// <summary>
        /// <para>
        /// <para>The name of the schema registry that contains the schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchemaId_RegistryName { get; set; }
        #endregion
        
        #region Parameter SchemaId_SchemaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the schema. One of <c>SchemaArn</c> or <c>SchemaName</c>
        /// has to be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SchemaId_SchemaArn { get; set; }
        #endregion
        
        #region Parameter SchemaId_SchemaName
        /// <summary>
        /// <para>
        /// <para>The name of the schema. One of <c>SchemaArn</c> or <c>SchemaName</c> has to be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchemaId_SchemaName { get; set; }
        #endregion
        
        #region Parameter SchemaVersionNumber_VersionNumber
        /// <summary>
        /// <para>
        /// <para>The version number of the schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? SchemaVersionNumber_VersionNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.UpdateSchemaResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.UpdateSchemaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SchemaId_SchemaArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SchemaId_SchemaArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SchemaId_SchemaArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GLUESchema (UpdateSchema)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.UpdateSchemaResponse, UpdateGLUESchemaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SchemaId_SchemaArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Compatibility = this.Compatibility;
            context.Description = this.Description;
            context.SchemaId_RegistryName = this.SchemaId_RegistryName;
            context.SchemaId_SchemaArn = this.SchemaId_SchemaArn;
            context.SchemaId_SchemaName = this.SchemaId_SchemaName;
            context.SchemaVersionNumber_LatestVersion = this.SchemaVersionNumber_LatestVersion;
            context.SchemaVersionNumber_VersionNumber = this.SchemaVersionNumber_VersionNumber;
            
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
            var request = new Amazon.Glue.Model.UpdateSchemaRequest();
            
            if (cmdletContext.Compatibility != null)
            {
                request.Compatibility = cmdletContext.Compatibility;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate SchemaId
            var requestSchemaIdIsNull = true;
            request.SchemaId = new Amazon.Glue.Model.SchemaId();
            System.String requestSchemaId_schemaId_RegistryName = null;
            if (cmdletContext.SchemaId_RegistryName != null)
            {
                requestSchemaId_schemaId_RegistryName = cmdletContext.SchemaId_RegistryName;
            }
            if (requestSchemaId_schemaId_RegistryName != null)
            {
                request.SchemaId.RegistryName = requestSchemaId_schemaId_RegistryName;
                requestSchemaIdIsNull = false;
            }
            System.String requestSchemaId_schemaId_SchemaArn = null;
            if (cmdletContext.SchemaId_SchemaArn != null)
            {
                requestSchemaId_schemaId_SchemaArn = cmdletContext.SchemaId_SchemaArn;
            }
            if (requestSchemaId_schemaId_SchemaArn != null)
            {
                request.SchemaId.SchemaArn = requestSchemaId_schemaId_SchemaArn;
                requestSchemaIdIsNull = false;
            }
            System.String requestSchemaId_schemaId_SchemaName = null;
            if (cmdletContext.SchemaId_SchemaName != null)
            {
                requestSchemaId_schemaId_SchemaName = cmdletContext.SchemaId_SchemaName;
            }
            if (requestSchemaId_schemaId_SchemaName != null)
            {
                request.SchemaId.SchemaName = requestSchemaId_schemaId_SchemaName;
                requestSchemaIdIsNull = false;
            }
             // determine if request.SchemaId should be set to null
            if (requestSchemaIdIsNull)
            {
                request.SchemaId = null;
            }
            
             // populate SchemaVersionNumber
            var requestSchemaVersionNumberIsNull = true;
            request.SchemaVersionNumber = new Amazon.Glue.Model.SchemaVersionNumber();
            System.Boolean? requestSchemaVersionNumber_schemaVersionNumber_LatestVersion = null;
            if (cmdletContext.SchemaVersionNumber_LatestVersion != null)
            {
                requestSchemaVersionNumber_schemaVersionNumber_LatestVersion = cmdletContext.SchemaVersionNumber_LatestVersion.Value;
            }
            if (requestSchemaVersionNumber_schemaVersionNumber_LatestVersion != null)
            {
                request.SchemaVersionNumber.LatestVersion = requestSchemaVersionNumber_schemaVersionNumber_LatestVersion.Value;
                requestSchemaVersionNumberIsNull = false;
            }
            System.Int64? requestSchemaVersionNumber_schemaVersionNumber_VersionNumber = null;
            if (cmdletContext.SchemaVersionNumber_VersionNumber != null)
            {
                requestSchemaVersionNumber_schemaVersionNumber_VersionNumber = cmdletContext.SchemaVersionNumber_VersionNumber.Value;
            }
            if (requestSchemaVersionNumber_schemaVersionNumber_VersionNumber != null)
            {
                request.SchemaVersionNumber.VersionNumber = requestSchemaVersionNumber_schemaVersionNumber_VersionNumber.Value;
                requestSchemaVersionNumberIsNull = false;
            }
             // determine if request.SchemaVersionNumber should be set to null
            if (requestSchemaVersionNumberIsNull)
            {
                request.SchemaVersionNumber = null;
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
        
        private Amazon.Glue.Model.UpdateSchemaResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.UpdateSchemaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "UpdateSchema");
            try
            {
                #if DESKTOP
                return client.UpdateSchema(request);
                #elif CORECLR
                return client.UpdateSchemaAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Glue.Compatibility Compatibility { get; set; }
            public System.String Description { get; set; }
            public System.String SchemaId_RegistryName { get; set; }
            public System.String SchemaId_SchemaArn { get; set; }
            public System.String SchemaId_SchemaName { get; set; }
            public System.Boolean? SchemaVersionNumber_LatestVersion { get; set; }
            public System.Int64? SchemaVersionNumber_VersionNumber { get; set; }
            public System.Func<Amazon.Glue.Model.UpdateSchemaResponse, UpdateGLUESchemaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
