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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Creates a new analysis template.
    /// </summary>
    [Cmdlet("New", "CRSAnalysisTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.AnalysisTemplate")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service CreateAnalysisTemplate API operation.", Operation = new[] {"CreateAnalysisTemplate"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.CreateAnalysisTemplateResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.AnalysisTemplate or Amazon.CleanRooms.Model.CreateAnalysisTemplateResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.AnalysisTemplate object.",
        "The service call response (type Amazon.CleanRooms.Model.CreateAnalysisTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCRSAnalysisTemplateCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Artifacts_AdditionalArtifact
        /// <summary>
        /// <para>
        /// <para> Additional artifacts for the analysis template.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_Artifacts_AdditionalArtifacts")]
        public Amazon.CleanRooms.Model.AnalysisTemplateArtifact[] Artifacts_AdditionalArtifact { get; set; }
        #endregion
        
        #region Parameter AnalysisParameter
        /// <summary>
        /// <para>
        /// <para>The parameters of the analysis template.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalysisParameters")]
        public Amazon.CleanRooms.Model.AnalysisParameter[] AnalysisParameter { get; set; }
        #endregion
        
        #region Parameter Location_Bucket
        /// <summary>
        /// <para>
        /// <para> The bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_Artifacts_EntryPoint_Location_Bucket")]
        public System.String Location_Bucket { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the analysis template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>The format of the analysis template.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.AnalysisFormat")]
        public Amazon.CleanRooms.AnalysisFormat Format { get; set; }
        #endregion
        
        #region Parameter Location_Key
        /// <summary>
        /// <para>
        /// <para> The object key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_Artifacts_EntryPoint_Location_Key")]
        public System.String Location_Key { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for a membership resource.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the analysis template.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Schema_ReferencedTable
        /// <summary>
        /// <para>
        /// <para>The tables referenced in the analysis schema.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schema_ReferencedTables")]
        public System.String[] Schema_ReferencedTable { get; set; }
        #endregion
        
        #region Parameter Artifacts_RoleArn
        /// <summary>
        /// <para>
        /// <para> The role ARN for the analysis template artifacts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_Artifacts_RoleArn")]
        public System.String Artifacts_RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional label that you can assign to a resource when you create it. Each tag consists
        /// of a key and an optional value, both of which you define. When you use tagging, you
        /// can also use tag-based access control in IAM policies to control access to this resource.</para><para />
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
        
        #region Parameter Source_Text
        /// <summary>
        /// <para>
        /// <para>The query text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_Text { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnalysisTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.CreateAnalysisTemplateResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.CreateAnalysisTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnalysisTemplate";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRSAnalysisTemplate (CreateAnalysisTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.CreateAnalysisTemplateResponse, NewCRSAnalysisTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AnalysisParameter != null)
            {
                context.AnalysisParameter = new List<Amazon.CleanRooms.Model.AnalysisParameter>(this.AnalysisParameter);
            }
            context.Description = this.Description;
            context.Format = this.Format;
            #if MODULAR
            if (this.Format == null && ParameterWasBound(nameof(this.Format)))
            {
                WriteWarning("You are passing $null as a value for parameter Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Schema_ReferencedTable != null)
            {
                context.Schema_ReferencedTable = new List<System.String>(this.Schema_ReferencedTable);
            }
            if (this.Artifacts_AdditionalArtifact != null)
            {
                context.Artifacts_AdditionalArtifact = new List<Amazon.CleanRooms.Model.AnalysisTemplateArtifact>(this.Artifacts_AdditionalArtifact);
            }
            context.Location_Bucket = this.Location_Bucket;
            context.Location_Key = this.Location_Key;
            context.Artifacts_RoleArn = this.Artifacts_RoleArn;
            context.Source_Text = this.Source_Text;
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
            var request = new Amazon.CleanRooms.Model.CreateAnalysisTemplateRequest();
            
            if (cmdletContext.AnalysisParameter != null)
            {
                request.AnalysisParameters = cmdletContext.AnalysisParameter;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Schema
            var requestSchemaIsNull = true;
            request.Schema = new Amazon.CleanRooms.Model.AnalysisSchema();
            List<System.String> requestSchema_schema_ReferencedTable = null;
            if (cmdletContext.Schema_ReferencedTable != null)
            {
                requestSchema_schema_ReferencedTable = cmdletContext.Schema_ReferencedTable;
            }
            if (requestSchema_schema_ReferencedTable != null)
            {
                request.Schema.ReferencedTables = requestSchema_schema_ReferencedTable;
                requestSchemaIsNull = false;
            }
             // determine if request.Schema should be set to null
            if (requestSchemaIsNull)
            {
                request.Schema = null;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.CleanRooms.Model.AnalysisSource();
            System.String requestSource_source_Text = null;
            if (cmdletContext.Source_Text != null)
            {
                requestSource_source_Text = cmdletContext.Source_Text;
            }
            if (requestSource_source_Text != null)
            {
                request.Source.Text = requestSource_source_Text;
                requestSourceIsNull = false;
            }
            Amazon.CleanRooms.Model.AnalysisTemplateArtifacts requestSource_source_Artifacts = null;
            
             // populate Artifacts
            var requestSource_source_ArtifactsIsNull = true;
            requestSource_source_Artifacts = new Amazon.CleanRooms.Model.AnalysisTemplateArtifacts();
            List<Amazon.CleanRooms.Model.AnalysisTemplateArtifact> requestSource_source_Artifacts_artifacts_AdditionalArtifact = null;
            if (cmdletContext.Artifacts_AdditionalArtifact != null)
            {
                requestSource_source_Artifacts_artifacts_AdditionalArtifact = cmdletContext.Artifacts_AdditionalArtifact;
            }
            if (requestSource_source_Artifacts_artifacts_AdditionalArtifact != null)
            {
                requestSource_source_Artifacts.AdditionalArtifacts = requestSource_source_Artifacts_artifacts_AdditionalArtifact;
                requestSource_source_ArtifactsIsNull = false;
            }
            System.String requestSource_source_Artifacts_artifacts_RoleArn = null;
            if (cmdletContext.Artifacts_RoleArn != null)
            {
                requestSource_source_Artifacts_artifacts_RoleArn = cmdletContext.Artifacts_RoleArn;
            }
            if (requestSource_source_Artifacts_artifacts_RoleArn != null)
            {
                requestSource_source_Artifacts.RoleArn = requestSource_source_Artifacts_artifacts_RoleArn;
                requestSource_source_ArtifactsIsNull = false;
            }
            Amazon.CleanRooms.Model.AnalysisTemplateArtifact requestSource_source_Artifacts_source_Artifacts_EntryPoint = null;
            
             // populate EntryPoint
            var requestSource_source_Artifacts_source_Artifacts_EntryPointIsNull = true;
            requestSource_source_Artifacts_source_Artifacts_EntryPoint = new Amazon.CleanRooms.Model.AnalysisTemplateArtifact();
            Amazon.CleanRooms.Model.S3Location requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location = null;
            
             // populate Location
            var requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_LocationIsNull = true;
            requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location = new Amazon.CleanRooms.Model.S3Location();
            System.String requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location_location_Bucket = null;
            if (cmdletContext.Location_Bucket != null)
            {
                requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location_location_Bucket = cmdletContext.Location_Bucket;
            }
            if (requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location_location_Bucket != null)
            {
                requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location.Bucket = requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location_location_Bucket;
                requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_LocationIsNull = false;
            }
            System.String requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location_location_Key = null;
            if (cmdletContext.Location_Key != null)
            {
                requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location_location_Key = cmdletContext.Location_Key;
            }
            if (requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location_location_Key != null)
            {
                requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location.Key = requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location_location_Key;
                requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_LocationIsNull = false;
            }
             // determine if requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location should be set to null
            if (requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_LocationIsNull)
            {
                requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location = null;
            }
            if (requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location != null)
            {
                requestSource_source_Artifacts_source_Artifacts_EntryPoint.Location = requestSource_source_Artifacts_source_Artifacts_EntryPoint_source_Artifacts_EntryPoint_Location;
                requestSource_source_Artifacts_source_Artifacts_EntryPointIsNull = false;
            }
             // determine if requestSource_source_Artifacts_source_Artifacts_EntryPoint should be set to null
            if (requestSource_source_Artifacts_source_Artifacts_EntryPointIsNull)
            {
                requestSource_source_Artifacts_source_Artifacts_EntryPoint = null;
            }
            if (requestSource_source_Artifacts_source_Artifacts_EntryPoint != null)
            {
                requestSource_source_Artifacts.EntryPoint = requestSource_source_Artifacts_source_Artifacts_EntryPoint;
                requestSource_source_ArtifactsIsNull = false;
            }
             // determine if requestSource_source_Artifacts should be set to null
            if (requestSource_source_ArtifactsIsNull)
            {
                requestSource_source_Artifacts = null;
            }
            if (requestSource_source_Artifacts != null)
            {
                request.Source.Artifacts = requestSource_source_Artifacts;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
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
        
        private Amazon.CleanRooms.Model.CreateAnalysisTemplateResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.CreateAnalysisTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "CreateAnalysisTemplate");
            try
            {
                return client.CreateAnalysisTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.CleanRooms.Model.AnalysisParameter> AnalysisParameter { get; set; }
            public System.String Description { get; set; }
            public Amazon.CleanRooms.AnalysisFormat Format { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.String Name { get; set; }
            public List<System.String> Schema_ReferencedTable { get; set; }
            public List<Amazon.CleanRooms.Model.AnalysisTemplateArtifact> Artifacts_AdditionalArtifact { get; set; }
            public System.String Location_Bucket { get; set; }
            public System.String Location_Key { get; set; }
            public System.String Artifacts_RoleArn { get; set; }
            public System.String Source_Text { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CleanRooms.Model.CreateAnalysisTemplateResponse, NewCRSAnalysisTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnalysisTemplate;
        }
        
    }
}
