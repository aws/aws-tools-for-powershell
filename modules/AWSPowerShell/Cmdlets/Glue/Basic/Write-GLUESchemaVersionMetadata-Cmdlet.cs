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
    /// Puts the metadata key value pair for a specified schema version ID. A maximum of 10
    /// key value pairs will be allowed per schema version. They can be added over one or
    /// more calls.
    /// </summary>
    [Cmdlet("Write", "GLUESchemaVersionMetadata", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.PutSchemaVersionMetadataResponse")]
    [AWSCmdlet("Calls the AWS Glue PutSchemaVersionMetadata API operation.", Operation = new[] {"PutSchemaVersionMetadata"}, SelectReturnType = typeof(Amazon.Glue.Model.PutSchemaVersionMetadataResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.PutSchemaVersionMetadataResponse",
        "This cmdlet returns an Amazon.Glue.Model.PutSchemaVersionMetadataResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteGLUESchemaVersionMetadataCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SchemaVersionNumber_LatestVersion
        /// <summary>
        /// <para>
        /// <para>The latest version available for the schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SchemaVersionNumber_LatestVersion { get; set; }
        #endregion
        
        #region Parameter MetadataKeyValue_MetadataKey
        /// <summary>
        /// <para>
        /// <para>A metadata key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataKeyValue_MetadataKey { get; set; }
        #endregion
        
        #region Parameter MetadataKeyValue_MetadataValue
        /// <summary>
        /// <para>
        /// <para>A metadata key’s corresponding value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataKeyValue_MetadataValue { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter SchemaVersionId
        /// <summary>
        /// <para>
        /// <para>The unique version ID of the schema version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SchemaVersionId { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.PutSchemaVersionMetadataResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.PutSchemaVersionMetadataResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SchemaVersionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-GLUESchemaVersionMetadata (PutSchemaVersionMetadata)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.PutSchemaVersionMetadataResponse, WriteGLUESchemaVersionMetadataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MetadataKeyValue_MetadataKey = this.MetadataKeyValue_MetadataKey;
            context.MetadataKeyValue_MetadataValue = this.MetadataKeyValue_MetadataValue;
            context.SchemaId_RegistryName = this.SchemaId_RegistryName;
            context.SchemaId_SchemaArn = this.SchemaId_SchemaArn;
            context.SchemaId_SchemaName = this.SchemaId_SchemaName;
            context.SchemaVersionId = this.SchemaVersionId;
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
            var request = new Amazon.Glue.Model.PutSchemaVersionMetadataRequest();
            
            
             // populate MetadataKeyValue
            var requestMetadataKeyValueIsNull = true;
            request.MetadataKeyValue = new Amazon.Glue.Model.MetadataKeyValuePair();
            System.String requestMetadataKeyValue_metadataKeyValue_MetadataKey = null;
            if (cmdletContext.MetadataKeyValue_MetadataKey != null)
            {
                requestMetadataKeyValue_metadataKeyValue_MetadataKey = cmdletContext.MetadataKeyValue_MetadataKey;
            }
            if (requestMetadataKeyValue_metadataKeyValue_MetadataKey != null)
            {
                request.MetadataKeyValue.MetadataKey = requestMetadataKeyValue_metadataKeyValue_MetadataKey;
                requestMetadataKeyValueIsNull = false;
            }
            System.String requestMetadataKeyValue_metadataKeyValue_MetadataValue = null;
            if (cmdletContext.MetadataKeyValue_MetadataValue != null)
            {
                requestMetadataKeyValue_metadataKeyValue_MetadataValue = cmdletContext.MetadataKeyValue_MetadataValue;
            }
            if (requestMetadataKeyValue_metadataKeyValue_MetadataValue != null)
            {
                request.MetadataKeyValue.MetadataValue = requestMetadataKeyValue_metadataKeyValue_MetadataValue;
                requestMetadataKeyValueIsNull = false;
            }
             // determine if request.MetadataKeyValue should be set to null
            if (requestMetadataKeyValueIsNull)
            {
                request.MetadataKeyValue = null;
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
            if (cmdletContext.SchemaVersionId != null)
            {
                request.SchemaVersionId = cmdletContext.SchemaVersionId;
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
        
        private Amazon.Glue.Model.PutSchemaVersionMetadataResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.PutSchemaVersionMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "PutSchemaVersionMetadata");
            try
            {
                #if DESKTOP
                return client.PutSchemaVersionMetadata(request);
                #elif CORECLR
                return client.PutSchemaVersionMetadataAsync(request).GetAwaiter().GetResult();
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
            public System.String MetadataKeyValue_MetadataKey { get; set; }
            public System.String MetadataKeyValue_MetadataValue { get; set; }
            public System.String SchemaId_RegistryName { get; set; }
            public System.String SchemaId_SchemaArn { get; set; }
            public System.String SchemaId_SchemaName { get; set; }
            public System.String SchemaVersionId { get; set; }
            public System.Boolean? SchemaVersionNumber_LatestVersion { get; set; }
            public System.Int64? SchemaVersionNumber_VersionNumber { get; set; }
            public System.Func<Amazon.Glue.Model.PutSchemaVersionMetadataResponse, WriteGLUESchemaVersionMetadataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
