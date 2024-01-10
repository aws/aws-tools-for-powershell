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
    /// Fetches the schema version difference in the specified difference type between two
    /// stored schema versions in the Schema Registry.
    /// 
    ///  
    /// <para>
    /// This API allows you to compare two schema versions between two schema definitions
    /// under the same schema.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "GLUESchemaVersionsDiff")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue GetSchemaVersionsDiff API operation.", Operation = new[] {"GetSchemaVersionsDiff"}, SelectReturnType = typeof(Amazon.Glue.Model.GetSchemaVersionsDiffResponse))]
    [AWSCmdletOutput("System.String or Amazon.Glue.Model.GetSchemaVersionsDiffResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Glue.Model.GetSchemaVersionsDiffResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGLUESchemaVersionsDiffCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FirstSchemaVersionNumber_LatestVersion
        /// <summary>
        /// <para>
        /// <para>The latest version available for the schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? FirstSchemaVersionNumber_LatestVersion { get; set; }
        #endregion
        
        #region Parameter SecondSchemaVersionNumber_LatestVersion
        /// <summary>
        /// <para>
        /// <para>The latest version available for the schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecondSchemaVersionNumber_LatestVersion { get; set; }
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
        
        #region Parameter SchemaDiffType
        /// <summary>
        /// <para>
        /// <para>Refers to <c>SYNTAX_DIFF</c>, which is the currently supported diff type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Glue.SchemaDiffType")]
        public Amazon.Glue.SchemaDiffType SchemaDiffType { get; set; }
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
        
        #region Parameter FirstSchemaVersionNumber_VersionNumber
        /// <summary>
        /// <para>
        /// <para>The version number of the schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? FirstSchemaVersionNumber_VersionNumber { get; set; }
        #endregion
        
        #region Parameter SecondSchemaVersionNumber_VersionNumber
        /// <summary>
        /// <para>
        /// <para>The version number of the schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? SecondSchemaVersionNumber_VersionNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Diff'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.GetSchemaVersionsDiffResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.GetSchemaVersionsDiffResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Diff";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SchemaDiffType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SchemaDiffType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SchemaDiffType' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.GetSchemaVersionsDiffResponse, GetGLUESchemaVersionsDiffCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SchemaDiffType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FirstSchemaVersionNumber_LatestVersion = this.FirstSchemaVersionNumber_LatestVersion;
            context.FirstSchemaVersionNumber_VersionNumber = this.FirstSchemaVersionNumber_VersionNumber;
            context.SchemaDiffType = this.SchemaDiffType;
            #if MODULAR
            if (this.SchemaDiffType == null && ParameterWasBound(nameof(this.SchemaDiffType)))
            {
                WriteWarning("You are passing $null as a value for parameter SchemaDiffType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SchemaId_RegistryName = this.SchemaId_RegistryName;
            context.SchemaId_SchemaArn = this.SchemaId_SchemaArn;
            context.SchemaId_SchemaName = this.SchemaId_SchemaName;
            context.SecondSchemaVersionNumber_LatestVersion = this.SecondSchemaVersionNumber_LatestVersion;
            context.SecondSchemaVersionNumber_VersionNumber = this.SecondSchemaVersionNumber_VersionNumber;
            
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
            var request = new Amazon.Glue.Model.GetSchemaVersionsDiffRequest();
            
            
             // populate FirstSchemaVersionNumber
            var requestFirstSchemaVersionNumberIsNull = true;
            request.FirstSchemaVersionNumber = new Amazon.Glue.Model.SchemaVersionNumber();
            System.Boolean? requestFirstSchemaVersionNumber_firstSchemaVersionNumber_LatestVersion = null;
            if (cmdletContext.FirstSchemaVersionNumber_LatestVersion != null)
            {
                requestFirstSchemaVersionNumber_firstSchemaVersionNumber_LatestVersion = cmdletContext.FirstSchemaVersionNumber_LatestVersion.Value;
            }
            if (requestFirstSchemaVersionNumber_firstSchemaVersionNumber_LatestVersion != null)
            {
                request.FirstSchemaVersionNumber.LatestVersion = requestFirstSchemaVersionNumber_firstSchemaVersionNumber_LatestVersion.Value;
                requestFirstSchemaVersionNumberIsNull = false;
            }
            System.Int64? requestFirstSchemaVersionNumber_firstSchemaVersionNumber_VersionNumber = null;
            if (cmdletContext.FirstSchemaVersionNumber_VersionNumber != null)
            {
                requestFirstSchemaVersionNumber_firstSchemaVersionNumber_VersionNumber = cmdletContext.FirstSchemaVersionNumber_VersionNumber.Value;
            }
            if (requestFirstSchemaVersionNumber_firstSchemaVersionNumber_VersionNumber != null)
            {
                request.FirstSchemaVersionNumber.VersionNumber = requestFirstSchemaVersionNumber_firstSchemaVersionNumber_VersionNumber.Value;
                requestFirstSchemaVersionNumberIsNull = false;
            }
             // determine if request.FirstSchemaVersionNumber should be set to null
            if (requestFirstSchemaVersionNumberIsNull)
            {
                request.FirstSchemaVersionNumber = null;
            }
            if (cmdletContext.SchemaDiffType != null)
            {
                request.SchemaDiffType = cmdletContext.SchemaDiffType;
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
            
             // populate SecondSchemaVersionNumber
            var requestSecondSchemaVersionNumberIsNull = true;
            request.SecondSchemaVersionNumber = new Amazon.Glue.Model.SchemaVersionNumber();
            System.Boolean? requestSecondSchemaVersionNumber_secondSchemaVersionNumber_LatestVersion = null;
            if (cmdletContext.SecondSchemaVersionNumber_LatestVersion != null)
            {
                requestSecondSchemaVersionNumber_secondSchemaVersionNumber_LatestVersion = cmdletContext.SecondSchemaVersionNumber_LatestVersion.Value;
            }
            if (requestSecondSchemaVersionNumber_secondSchemaVersionNumber_LatestVersion != null)
            {
                request.SecondSchemaVersionNumber.LatestVersion = requestSecondSchemaVersionNumber_secondSchemaVersionNumber_LatestVersion.Value;
                requestSecondSchemaVersionNumberIsNull = false;
            }
            System.Int64? requestSecondSchemaVersionNumber_secondSchemaVersionNumber_VersionNumber = null;
            if (cmdletContext.SecondSchemaVersionNumber_VersionNumber != null)
            {
                requestSecondSchemaVersionNumber_secondSchemaVersionNumber_VersionNumber = cmdletContext.SecondSchemaVersionNumber_VersionNumber.Value;
            }
            if (requestSecondSchemaVersionNumber_secondSchemaVersionNumber_VersionNumber != null)
            {
                request.SecondSchemaVersionNumber.VersionNumber = requestSecondSchemaVersionNumber_secondSchemaVersionNumber_VersionNumber.Value;
                requestSecondSchemaVersionNumberIsNull = false;
            }
             // determine if request.SecondSchemaVersionNumber should be set to null
            if (requestSecondSchemaVersionNumberIsNull)
            {
                request.SecondSchemaVersionNumber = null;
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
        
        private Amazon.Glue.Model.GetSchemaVersionsDiffResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetSchemaVersionsDiffRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetSchemaVersionsDiff");
            try
            {
                #if DESKTOP
                return client.GetSchemaVersionsDiff(request);
                #elif CORECLR
                return client.GetSchemaVersionsDiffAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? FirstSchemaVersionNumber_LatestVersion { get; set; }
            public System.Int64? FirstSchemaVersionNumber_VersionNumber { get; set; }
            public Amazon.Glue.SchemaDiffType SchemaDiffType { get; set; }
            public System.String SchemaId_RegistryName { get; set; }
            public System.String SchemaId_SchemaArn { get; set; }
            public System.String SchemaId_SchemaName { get; set; }
            public System.Boolean? SecondSchemaVersionNumber_LatestVersion { get; set; }
            public System.Int64? SecondSchemaVersionNumber_VersionNumber { get; set; }
            public System.Func<Amazon.Glue.Model.GetSchemaVersionsDiffResponse, GetGLUESchemaVersionsDiffCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Diff;
        }
        
    }
}
