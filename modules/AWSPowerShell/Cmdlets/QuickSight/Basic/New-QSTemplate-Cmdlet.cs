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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates a template from an existing QuickSight analysis or template. You can use the
    /// resulting template to create a dashboard.
    /// 
    ///  
    /// <para>
    /// A <i>template</i> is an entity in QuickSight that encapsulates the metadata required
    /// to create an analysis and that you can use to create s dashboard. A template adds
    /// a layer of abstraction by using placeholders to replace the dataset associated with
    /// the analysis. You can use templates to create dashboards by replacing dataset placeholders
    /// with datasets that follow the same schema that was used to create the source analysis
    /// and template.
    /// </para>
    /// </summary>
    [Cmdlet("New", "QSTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.CreateTemplateResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight CreateTemplate API operation.", Operation = new[] {"CreateTemplate"}, SelectReturnType = typeof(Amazon.QuickSight.Model.CreateTemplateResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.CreateTemplateResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.CreateTemplateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewQSTemplateCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        #region Parameter SourceAnalysis_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceEntity_SourceAnalysis_Arn")]
        public System.String SourceAnalysis_Arn { get; set; }
        #endregion
        
        #region Parameter SourceTemplate_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceEntity_SourceTemplate_Arn")]
        public System.String SourceTemplate_Arn { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID for the AWS account that the group is in. Currently, you use the ID for the
        /// AWS account that contains your Amazon QuickSight account.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter SourceAnalysis_DataSetReference
        /// <summary>
        /// <para>
        /// <para>A structure containing information about the dataset references used as placeholders
        /// in the template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceEntity_SourceAnalysis_DataSetReferences")]
        public Amazon.QuickSight.Model.DataSetReference[] SourceAnalysis_DataSetReference { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A display name for the template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Permission
        /// <summary>
        /// <para>
        /// <para>A list of resource permissions to be set on the template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Permissions")]
        public Amazon.QuickSight.Model.ResourcePermission[] Permission { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Contains a map of the key-value pairs for the resource tag or tags assigned to the
        /// resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QuickSight.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemplateId
        /// <summary>
        /// <para>
        /// <para>An ID for the template that you want to create. This template is unique per AWS Region
        /// in each AWS account.</para>
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
        public System.String TemplateId { get; set; }
        #endregion
        
        #region Parameter VersionDescription
        /// <summary>
        /// <para>
        /// <para>A description of the current template version being created. This API operation creates
        /// the first version of the template. Every time <code>UpdateTemplate</code> is called,
        /// a new version is created. Each version of the template maintains a description of
        /// the version in the <code>VersionDescription</code> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionDescription { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.CreateTemplateResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.CreateTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TemplateId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TemplateId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TemplateId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TemplateId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSTemplate (CreateTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateTemplateResponse, NewQSTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TemplateId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            if (this.Permission != null)
            {
                context.Permission = new List<Amazon.QuickSight.Model.ResourcePermission>(this.Permission);
            }
            context.SourceAnalysis_Arn = this.SourceAnalysis_Arn;
            if (this.SourceAnalysis_DataSetReference != null)
            {
                context.SourceAnalysis_DataSetReference = new List<Amazon.QuickSight.Model.DataSetReference>(this.SourceAnalysis_DataSetReference);
            }
            context.SourceTemplate_Arn = this.SourceTemplate_Arn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QuickSight.Model.Tag>(this.Tag);
            }
            context.TemplateId = this.TemplateId;
            #if MODULAR
            if (this.TemplateId == null && ParameterWasBound(nameof(this.TemplateId)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VersionDescription = this.VersionDescription;
            
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
            var request = new Amazon.QuickSight.Model.CreateTemplateRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Permission != null)
            {
                request.Permissions = cmdletContext.Permission;
            }
            
             // populate SourceEntity
            var requestSourceEntityIsNull = true;
            request.SourceEntity = new Amazon.QuickSight.Model.TemplateSourceEntity();
            Amazon.QuickSight.Model.TemplateSourceTemplate requestSourceEntity_sourceEntity_SourceTemplate = null;
            
             // populate SourceTemplate
            var requestSourceEntity_sourceEntity_SourceTemplateIsNull = true;
            requestSourceEntity_sourceEntity_SourceTemplate = new Amazon.QuickSight.Model.TemplateSourceTemplate();
            System.String requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_Arn = null;
            if (cmdletContext.SourceTemplate_Arn != null)
            {
                requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_Arn = cmdletContext.SourceTemplate_Arn;
            }
            if (requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_Arn != null)
            {
                requestSourceEntity_sourceEntity_SourceTemplate.Arn = requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_Arn;
                requestSourceEntity_sourceEntity_SourceTemplateIsNull = false;
            }
             // determine if requestSourceEntity_sourceEntity_SourceTemplate should be set to null
            if (requestSourceEntity_sourceEntity_SourceTemplateIsNull)
            {
                requestSourceEntity_sourceEntity_SourceTemplate = null;
            }
            if (requestSourceEntity_sourceEntity_SourceTemplate != null)
            {
                request.SourceEntity.SourceTemplate = requestSourceEntity_sourceEntity_SourceTemplate;
                requestSourceEntityIsNull = false;
            }
            Amazon.QuickSight.Model.TemplateSourceAnalysis requestSourceEntity_sourceEntity_SourceAnalysis = null;
            
             // populate SourceAnalysis
            var requestSourceEntity_sourceEntity_SourceAnalysisIsNull = true;
            requestSourceEntity_sourceEntity_SourceAnalysis = new Amazon.QuickSight.Model.TemplateSourceAnalysis();
            System.String requestSourceEntity_sourceEntity_SourceAnalysis_sourceAnalysis_Arn = null;
            if (cmdletContext.SourceAnalysis_Arn != null)
            {
                requestSourceEntity_sourceEntity_SourceAnalysis_sourceAnalysis_Arn = cmdletContext.SourceAnalysis_Arn;
            }
            if (requestSourceEntity_sourceEntity_SourceAnalysis_sourceAnalysis_Arn != null)
            {
                requestSourceEntity_sourceEntity_SourceAnalysis.Arn = requestSourceEntity_sourceEntity_SourceAnalysis_sourceAnalysis_Arn;
                requestSourceEntity_sourceEntity_SourceAnalysisIsNull = false;
            }
            List<Amazon.QuickSight.Model.DataSetReference> requestSourceEntity_sourceEntity_SourceAnalysis_sourceAnalysis_DataSetReference = null;
            if (cmdletContext.SourceAnalysis_DataSetReference != null)
            {
                requestSourceEntity_sourceEntity_SourceAnalysis_sourceAnalysis_DataSetReference = cmdletContext.SourceAnalysis_DataSetReference;
            }
            if (requestSourceEntity_sourceEntity_SourceAnalysis_sourceAnalysis_DataSetReference != null)
            {
                requestSourceEntity_sourceEntity_SourceAnalysis.DataSetReferences = requestSourceEntity_sourceEntity_SourceAnalysis_sourceAnalysis_DataSetReference;
                requestSourceEntity_sourceEntity_SourceAnalysisIsNull = false;
            }
             // determine if requestSourceEntity_sourceEntity_SourceAnalysis should be set to null
            if (requestSourceEntity_sourceEntity_SourceAnalysisIsNull)
            {
                requestSourceEntity_sourceEntity_SourceAnalysis = null;
            }
            if (requestSourceEntity_sourceEntity_SourceAnalysis != null)
            {
                request.SourceEntity.SourceAnalysis = requestSourceEntity_sourceEntity_SourceAnalysis;
                requestSourceEntityIsNull = false;
            }
             // determine if request.SourceEntity should be set to null
            if (requestSourceEntityIsNull)
            {
                request.SourceEntity = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TemplateId != null)
            {
                request.TemplateId = cmdletContext.TemplateId;
            }
            if (cmdletContext.VersionDescription != null)
            {
                request.VersionDescription = cmdletContext.VersionDescription;
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
        
        private Amazon.QuickSight.Model.CreateTemplateResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.CreateTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "CreateTemplate");
            try
            {
                #if DESKTOP
                return client.CreateTemplate(request);
                #elif CORECLR
                return client.CreateTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.QuickSight.Model.ResourcePermission> Permission { get; set; }
            public System.String SourceAnalysis_Arn { get; set; }
            public List<Amazon.QuickSight.Model.DataSetReference> SourceAnalysis_DataSetReference { get; set; }
            public System.String SourceTemplate_Arn { get; set; }
            public List<Amazon.QuickSight.Model.Tag> Tag { get; set; }
            public System.String TemplateId { get; set; }
            public System.String VersionDescription { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateTemplateResponse, NewQSTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
