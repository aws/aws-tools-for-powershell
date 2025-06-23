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
    /// Creates a new schema set and registers the schema definition. Returns an error if
    /// the schema set already exists without actually registering the version.
    /// 
    ///  
    /// <para>
    /// When the schema set is created, a version checkpoint will be set to the first version.
    /// Compatibility mode "DISABLED" restricts any additional schema versions from being
    /// added after the first schema version. For all other compatibility modes, validation
    /// of compatibility settings will be applied only from the second version onwards when
    /// the <c>RegisterSchemaVersion</c> API is used.
    /// </para><para>
    /// When this API is called without a <c>RegistryId</c>, this will create an entry for
    /// a "default-registry" in the registry database tables, if it is not already present.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GLUESchema", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.CreateSchemaResponse")]
    [AWSCmdlet("Calls the AWS Glue CreateSchema API operation.", Operation = new[] {"CreateSchema"}, SelectReturnType = typeof(Amazon.Glue.Model.CreateSchemaResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.CreateSchemaResponse",
        "This cmdlet returns an Amazon.Glue.Model.CreateSchemaResponse object containing multiple properties."
    )]
    public partial class NewGLUESchemaCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Compatibility
        /// <summary>
        /// <para>
        /// <para>The compatibility mode of the schema. The possible values are:</para><ul><li><para><i>NONE</i>: No compatibility mode applies. You can use this choice in development
        /// scenarios or if you do not know the compatibility mode that you want to apply to schemas.
        /// Any new version added will be accepted without undergoing a compatibility check.</para></li><li><para><i>DISABLED</i>: This compatibility choice prevents versioning for a particular schema.
        /// You can use this choice to prevent future versioning of a schema.</para></li><li><para><i>BACKWARD</i>: This compatibility choice is recommended as it allows data receivers
        /// to read both the current and one previous schema version. This means that for instance,
        /// a new schema version cannot drop data fields or change the type of these fields, so
        /// they can't be read by readers using the previous version.</para></li><li><para><i>BACKWARD_ALL</i>: This compatibility choice allows data receivers to read both
        /// the current and all previous schema versions. You can use this choice when you need
        /// to delete fields or add optional fields, and check compatibility against all previous
        /// schema versions. </para></li><li><para><i>FORWARD</i>: This compatibility choice allows data receivers to read both the
        /// current and one next schema version, but not necessarily later versions. You can use
        /// this choice when you need to add fields or delete optional fields, but only check
        /// compatibility against the last schema version.</para></li><li><para><i>FORWARD_ALL</i>: This compatibility choice allows data receivers to read written
        /// by producers of any new registered schema. You can use this choice when you need to
        /// add fields or delete optional fields, and check compatibility against all previous
        /// schema versions.</para></li><li><para><i>FULL</i>: This compatibility choice allows data receivers to read data written
        /// by producers using the previous or next version of the schema, but not necessarily
        /// earlier or later versions. You can use this choice when you need to add or remove
        /// optional fields, but only check compatibility against the last schema version.</para></li><li><para><i>FULL_ALL</i>: This compatibility choice allows data receivers to read data written
        /// by producers using all previous schema versions. You can use this choice when you
        /// need to add or remove optional fields, and check compatibility against all previous
        /// schema versions.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.Compatibility")]
        public Amazon.Glue.Compatibility Compatibility { get; set; }
        #endregion
        
        #region Parameter DataFormat
        /// <summary>
        /// <para>
        /// <para>The data format of the schema definition. Currently <c>AVRO</c>, <c>JSON</c> and <c>PROTOBUF</c>
        /// are supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Glue.DataFormat")]
        public Amazon.Glue.DataFormat DataFormat { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of the schema. If description is not provided, there will
        /// not be any automatic default value for this.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter RegistryId_RegistryArn
        /// <summary>
        /// <para>
        /// <para>Arn of the registry to be updated. One of <c>RegistryArn</c> or <c>RegistryName</c>
        /// has to be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId_RegistryArn { get; set; }
        #endregion
        
        #region Parameter RegistryId_RegistryName
        /// <summary>
        /// <para>
        /// <para>Name of the registry. Used only for lookup. One of <c>RegistryArn</c> or <c>RegistryName</c>
        /// has to be provided. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId_RegistryName { get; set; }
        #endregion
        
        #region Parameter SchemaDefinition
        /// <summary>
        /// <para>
        /// <para>The schema definition using the <c>DataFormat</c> setting for <c>SchemaName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchemaDefinition { get; set; }
        #endregion
        
        #region Parameter SchemaName
        /// <summary>
        /// <para>
        /// <para>Name of the schema to be created of max length of 255, and may only contain letters,
        /// numbers, hyphen, underscore, dollar sign, or hash mark. No whitespace.</para>
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
        public System.String SchemaName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Amazon Web Services tags that contain a key value pair and may be searched by console,
        /// command line, or API. If specified, follows the Amazon Web Services tags-on-create
        /// pattern.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CreateSchemaResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.CreateSchemaResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SchemaName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUESchema (CreateSchema)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CreateSchemaResponse, NewGLUESchemaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Compatibility = this.Compatibility;
            context.DataFormat = this.DataFormat;
            #if MODULAR
            if (this.DataFormat == null && ParameterWasBound(nameof(this.DataFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter DataFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.RegistryId_RegistryArn = this.RegistryId_RegistryArn;
            context.RegistryId_RegistryName = this.RegistryId_RegistryName;
            context.SchemaDefinition = this.SchemaDefinition;
            context.SchemaName = this.SchemaName;
            #if MODULAR
            if (this.SchemaName == null && ParameterWasBound(nameof(this.SchemaName)))
            {
                WriteWarning("You are passing $null as a value for parameter SchemaName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Glue.Model.CreateSchemaRequest();
            
            if (cmdletContext.Compatibility != null)
            {
                request.Compatibility = cmdletContext.Compatibility;
            }
            if (cmdletContext.DataFormat != null)
            {
                request.DataFormat = cmdletContext.DataFormat;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate RegistryId
            var requestRegistryIdIsNull = true;
            request.RegistryId = new Amazon.Glue.Model.RegistryId();
            System.String requestRegistryId_registryId_RegistryArn = null;
            if (cmdletContext.RegistryId_RegistryArn != null)
            {
                requestRegistryId_registryId_RegistryArn = cmdletContext.RegistryId_RegistryArn;
            }
            if (requestRegistryId_registryId_RegistryArn != null)
            {
                request.RegistryId.RegistryArn = requestRegistryId_registryId_RegistryArn;
                requestRegistryIdIsNull = false;
            }
            System.String requestRegistryId_registryId_RegistryName = null;
            if (cmdletContext.RegistryId_RegistryName != null)
            {
                requestRegistryId_registryId_RegistryName = cmdletContext.RegistryId_RegistryName;
            }
            if (requestRegistryId_registryId_RegistryName != null)
            {
                request.RegistryId.RegistryName = requestRegistryId_registryId_RegistryName;
                requestRegistryIdIsNull = false;
            }
             // determine if request.RegistryId should be set to null
            if (requestRegistryIdIsNull)
            {
                request.RegistryId = null;
            }
            if (cmdletContext.SchemaDefinition != null)
            {
                request.SchemaDefinition = cmdletContext.SchemaDefinition;
            }
            if (cmdletContext.SchemaName != null)
            {
                request.SchemaName = cmdletContext.SchemaName;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Glue.Model.CreateSchemaResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateSchemaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateSchema");
            try
            {
                return client.CreateSchemaAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Glue.DataFormat DataFormat { get; set; }
            public System.String Description { get; set; }
            public System.String RegistryId_RegistryArn { get; set; }
            public System.String RegistryId_RegistryName { get; set; }
            public System.String SchemaDefinition { get; set; }
            public System.String SchemaName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Glue.Model.CreateSchemaResponse, NewGLUESchemaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
