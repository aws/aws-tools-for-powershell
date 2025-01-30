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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Creates the migration project using the specified parameters.
    /// 
    ///  
    /// <para>
    /// You can run this action only after you create an instance profile and data providers
    /// using <a href="https://docs.aws.amazon.com/dms/latest/APIReference/API_CreateInstanceProfile.html">CreateInstanceProfile</a>
    /// and <a href="https://docs.aws.amazon.com/dms/latest/APIReference/API_CreateDataProvider.html">CreateDataProvider</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DMSMigrationProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.MigrationProject")]
    [AWSCmdlet("Calls the AWS Database Migration Service CreateMigrationProject API operation.", Operation = new[] {"CreateMigrationProject"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.CreateMigrationProjectResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.MigrationProject or Amazon.DatabaseMigrationService.Model.CreateMigrationProjectResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.MigrationProject object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.CreateMigrationProjectResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDMSMigrationProjectCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A user-friendly description of the migration project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InstanceProfileIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the associated instance profile. Identifiers must begin with a letter
        /// and must contain only ASCII letters, digits, and hyphens. They can't end with a hyphen,
        /// or contain two consecutive hyphens.</para>
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
        public System.String InstanceProfileIdentifier { get; set; }
        #endregion
        
        #region Parameter MigrationProjectName
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for the migration project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String MigrationProjectName { get; set; }
        #endregion
        
        #region Parameter SchemaConversionApplicationAttributes_S3BucketPath
        /// <summary>
        /// <para>
        /// <para>The path for the Amazon S3 bucket that the application uses for exporting assessment
        /// reports.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchemaConversionApplicationAttributes_S3BucketPath { get; set; }
        #endregion
        
        #region Parameter SchemaConversionApplicationAttributes_S3BucketRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the role the application uses to access its Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchemaConversionApplicationAttributes_S3BucketRoleArn { get; set; }
        #endregion
        
        #region Parameter SourceDataProviderDescriptor
        /// <summary>
        /// <para>
        /// <para>Information about the source data provider, including the name, ARN, and Secrets Manager
        /// parameters.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SourceDataProviderDescriptors")]
        public Amazon.DatabaseMigrationService.Model.DataProviderDescriptorDefinition[] SourceDataProviderDescriptor { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags to be assigned to the migration project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DatabaseMigrationService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetDataProviderDescriptor
        /// <summary>
        /// <para>
        /// <para>Information about the target data provider, including the name, ARN, and Amazon Web
        /// Services Secrets Manager parameters.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TargetDataProviderDescriptors")]
        public Amazon.DatabaseMigrationService.Model.DataProviderDescriptorDefinition[] TargetDataProviderDescriptor { get; set; }
        #endregion
        
        #region Parameter TransformationRule
        /// <summary>
        /// <para>
        /// <para>The settings in JSON format for migration rules. Migration rules make it possible
        /// for you to change the object names according to the rules that you specify. For example,
        /// you can change an object name to lowercase or uppercase, add or remove a prefix or
        /// suffix, or rename objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TransformationRules")]
        public System.String TransformationRule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MigrationProject'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.CreateMigrationProjectResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.CreateMigrationProjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MigrationProject";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MigrationProjectName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MigrationProjectName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MigrationProjectName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MigrationProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DMSMigrationProject (CreateMigrationProject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.CreateMigrationProjectResponse, NewDMSMigrationProjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MigrationProjectName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.InstanceProfileIdentifier = this.InstanceProfileIdentifier;
            #if MODULAR
            if (this.InstanceProfileIdentifier == null && ParameterWasBound(nameof(this.InstanceProfileIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceProfileIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MigrationProjectName = this.MigrationProjectName;
            context.SchemaConversionApplicationAttributes_S3BucketPath = this.SchemaConversionApplicationAttributes_S3BucketPath;
            context.SchemaConversionApplicationAttributes_S3BucketRoleArn = this.SchemaConversionApplicationAttributes_S3BucketRoleArn;
            if (this.SourceDataProviderDescriptor != null)
            {
                context.SourceDataProviderDescriptor = new List<Amazon.DatabaseMigrationService.Model.DataProviderDescriptorDefinition>(this.SourceDataProviderDescriptor);
            }
            #if MODULAR
            if (this.SourceDataProviderDescriptor == null && ParameterWasBound(nameof(this.SourceDataProviderDescriptor)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceDataProviderDescriptor which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DatabaseMigrationService.Model.Tag>(this.Tag);
            }
            if (this.TargetDataProviderDescriptor != null)
            {
                context.TargetDataProviderDescriptor = new List<Amazon.DatabaseMigrationService.Model.DataProviderDescriptorDefinition>(this.TargetDataProviderDescriptor);
            }
            #if MODULAR
            if (this.TargetDataProviderDescriptor == null && ParameterWasBound(nameof(this.TargetDataProviderDescriptor)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetDataProviderDescriptor which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransformationRule = this.TransformationRule;
            
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
            var request = new Amazon.DatabaseMigrationService.Model.CreateMigrationProjectRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InstanceProfileIdentifier != null)
            {
                request.InstanceProfileIdentifier = cmdletContext.InstanceProfileIdentifier;
            }
            if (cmdletContext.MigrationProjectName != null)
            {
                request.MigrationProjectName = cmdletContext.MigrationProjectName;
            }
            
             // populate SchemaConversionApplicationAttributes
            var requestSchemaConversionApplicationAttributesIsNull = true;
            request.SchemaConversionApplicationAttributes = new Amazon.DatabaseMigrationService.Model.SCApplicationAttributes();
            System.String requestSchemaConversionApplicationAttributes_schemaConversionApplicationAttributes_S3BucketPath = null;
            if (cmdletContext.SchemaConversionApplicationAttributes_S3BucketPath != null)
            {
                requestSchemaConversionApplicationAttributes_schemaConversionApplicationAttributes_S3BucketPath = cmdletContext.SchemaConversionApplicationAttributes_S3BucketPath;
            }
            if (requestSchemaConversionApplicationAttributes_schemaConversionApplicationAttributes_S3BucketPath != null)
            {
                request.SchemaConversionApplicationAttributes.S3BucketPath = requestSchemaConversionApplicationAttributes_schemaConversionApplicationAttributes_S3BucketPath;
                requestSchemaConversionApplicationAttributesIsNull = false;
            }
            System.String requestSchemaConversionApplicationAttributes_schemaConversionApplicationAttributes_S3BucketRoleArn = null;
            if (cmdletContext.SchemaConversionApplicationAttributes_S3BucketRoleArn != null)
            {
                requestSchemaConversionApplicationAttributes_schemaConversionApplicationAttributes_S3BucketRoleArn = cmdletContext.SchemaConversionApplicationAttributes_S3BucketRoleArn;
            }
            if (requestSchemaConversionApplicationAttributes_schemaConversionApplicationAttributes_S3BucketRoleArn != null)
            {
                request.SchemaConversionApplicationAttributes.S3BucketRoleArn = requestSchemaConversionApplicationAttributes_schemaConversionApplicationAttributes_S3BucketRoleArn;
                requestSchemaConversionApplicationAttributesIsNull = false;
            }
             // determine if request.SchemaConversionApplicationAttributes should be set to null
            if (requestSchemaConversionApplicationAttributesIsNull)
            {
                request.SchemaConversionApplicationAttributes = null;
            }
            if (cmdletContext.SourceDataProviderDescriptor != null)
            {
                request.SourceDataProviderDescriptors = cmdletContext.SourceDataProviderDescriptor;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetDataProviderDescriptor != null)
            {
                request.TargetDataProviderDescriptors = cmdletContext.TargetDataProviderDescriptor;
            }
            if (cmdletContext.TransformationRule != null)
            {
                request.TransformationRules = cmdletContext.TransformationRule;
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
        
        private Amazon.DatabaseMigrationService.Model.CreateMigrationProjectResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.CreateMigrationProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "CreateMigrationProject");
            try
            {
                #if DESKTOP
                return client.CreateMigrationProject(request);
                #elif CORECLR
                return client.CreateMigrationProjectAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String InstanceProfileIdentifier { get; set; }
            public System.String MigrationProjectName { get; set; }
            public System.String SchemaConversionApplicationAttributes_S3BucketPath { get; set; }
            public System.String SchemaConversionApplicationAttributes_S3BucketRoleArn { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.DataProviderDescriptorDefinition> SourceDataProviderDescriptor { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.Tag> Tag { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.DataProviderDescriptorDefinition> TargetDataProviderDescriptor { get; set; }
            public System.String TransformationRule { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.CreateMigrationProjectResponse, NewDMSMigrationProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MigrationProject;
        }
        
    }
}
