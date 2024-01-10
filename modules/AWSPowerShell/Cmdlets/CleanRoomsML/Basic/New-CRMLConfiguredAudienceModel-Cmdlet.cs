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
using Amazon.CleanRoomsML;
using Amazon.CleanRoomsML.Model;

namespace Amazon.PowerShell.Cmdlets.CRML
{
    /// <summary>
    /// Defines the information necessary to create a configured audience model.
    /// </summary>
    [Cmdlet("New", "CRMLConfiguredAudienceModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the CleanRoomsML CreateConfiguredAudienceModel API operation.", Operation = new[] {"CreateConfiguredAudienceModel"}, SelectReturnType = typeof(Amazon.CleanRoomsML.Model.CreateConfiguredAudienceModelResponse))]
    [AWSCmdletOutput("System.String or Amazon.CleanRoomsML.Model.CreateConfiguredAudienceModelResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CleanRoomsML.Model.CreateConfiguredAudienceModelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCRMLConfiguredAudienceModelCmdlet : AmazonCleanRoomsMLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AudienceModelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the audience model to use for the configured audience
        /// model.</para>
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
        public System.String AudienceModelArn { get; set; }
        #endregion
        
        #region Parameter AudienceSizeConfig_AudienceSizeBin
        /// <summary>
        /// <para>
        /// <para>An array of the different audience output sizes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AudienceSizeConfig_AudienceSizeBins")]
        public System.Int32[] AudienceSizeConfig_AudienceSizeBin { get; set; }
        #endregion
        
        #region Parameter AudienceSizeConfig_AudienceSizeType
        /// <summary>
        /// <para>
        /// <para>Whether the audience output sizes are defined as an absolute number or a percentage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CleanRoomsML.AudienceSizeType")]
        public Amazon.CleanRoomsML.AudienceSizeType AudienceSizeConfig_AudienceSizeType { get; set; }
        #endregion
        
        #region Parameter ChildResourceTagOnCreatePolicy
        /// <summary>
        /// <para>
        /// <para>Configure how the service tags audience generation jobs created using this configured
        /// audience model. If you specify <c>NONE</c>, the tags from the <a>StartAudienceGenerationJob</a>
        /// request determine the tags of the audience generation job. If you specify <c>FROM_PARENT_RESOURCE</c>,
        /// the audience generation job inherits the tags from the configured audience model,
        /// by default. Tags in the <a>StartAudienceGenerationJob</a> will override the default.</para><para>When the client is in a different account than the configured audience model, the
        /// tags from the client are never applied to a resource in the caller's account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CleanRoomsML.TagOnCreatePolicy")]
        public Amazon.CleanRoomsML.TagOnCreatePolicy ChildResourceTagOnCreatePolicy { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the configured audience model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MinMatchingSeedSize
        /// <summary>
        /// <para>
        /// <para>The minimum number of users from the seed audience that must match with users in the
        /// training data of the audience model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinMatchingSeedSize { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the configured audience model.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OutputConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that can write the Amazon S3 bucket.</para>
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
        public System.String OutputConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter S3Destination_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location URI.</para>
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
        [Alias("OutputConfig_Destination_S3Destination_S3Uri")]
        public System.String S3Destination_S3Uri { get; set; }
        #endregion
        
        #region Parameter SharedAudienceMetric
        /// <summary>
        /// <para>
        /// <para>Whether audience metrics are shared.</para>
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
        [Alias("SharedAudienceMetrics")]
        public System.String[] SharedAudienceMetric { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The optional metadata that you apply to the resource to help you categorize and organize
        /// them. Each tag consists of a key and an optional value, both of which you define.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50.</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length - 128 Unicode characters in UTF-8.</para></li><li><para>Maximum value length - 256 Unicode characters in UTF-8.</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case sensitive.</para></li><li><para>Do not use aws:, AWS:, or any upper or lowercase combination of such as a prefix for
        /// keys as it is reserved for AWS use. You cannot edit or delete tag keys with this prefix.
        /// Values can have this prefix. If a tag value has aws as its prefix but the key does
        /// not, then Forecast considers it to be a user tag and will count against the limit
        /// of 50 tags. Tags with only the key prefix of aws do not count against your tags per
        /// resource limit.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfiguredAudienceModelArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRoomsML.Model.CreateConfiguredAudienceModelResponse).
        /// Specifying the name of a property of type Amazon.CleanRoomsML.Model.CreateConfiguredAudienceModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfiguredAudienceModelArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRMLConfiguredAudienceModel (CreateConfiguredAudienceModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRoomsML.Model.CreateConfiguredAudienceModelResponse, NewCRMLConfiguredAudienceModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AudienceModelArn = this.AudienceModelArn;
            #if MODULAR
            if (this.AudienceModelArn == null && ParameterWasBound(nameof(this.AudienceModelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AudienceModelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AudienceSizeConfig_AudienceSizeBin != null)
            {
                context.AudienceSizeConfig_AudienceSizeBin = new List<System.Int32>(this.AudienceSizeConfig_AudienceSizeBin);
            }
            context.AudienceSizeConfig_AudienceSizeType = this.AudienceSizeConfig_AudienceSizeType;
            context.ChildResourceTagOnCreatePolicy = this.ChildResourceTagOnCreatePolicy;
            context.Description = this.Description;
            context.MinMatchingSeedSize = this.MinMatchingSeedSize;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Destination_S3Uri = this.S3Destination_S3Uri;
            #if MODULAR
            if (this.S3Destination_S3Uri == null && ParameterWasBound(nameof(this.S3Destination_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Destination_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputConfig_RoleArn = this.OutputConfig_RoleArn;
            #if MODULAR
            if (this.OutputConfig_RoleArn == null && ParameterWasBound(nameof(this.OutputConfig_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfig_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SharedAudienceMetric != null)
            {
                context.SharedAudienceMetric = new List<System.String>(this.SharedAudienceMetric);
            }
            #if MODULAR
            if (this.SharedAudienceMetric == null && ParameterWasBound(nameof(this.SharedAudienceMetric)))
            {
                WriteWarning("You are passing $null as a value for parameter SharedAudienceMetric which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.CleanRoomsML.Model.CreateConfiguredAudienceModelRequest();
            
            if (cmdletContext.AudienceModelArn != null)
            {
                request.AudienceModelArn = cmdletContext.AudienceModelArn;
            }
            
             // populate AudienceSizeConfig
            var requestAudienceSizeConfigIsNull = true;
            request.AudienceSizeConfig = new Amazon.CleanRoomsML.Model.AudienceSizeConfig();
            List<System.Int32> requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeBin = null;
            if (cmdletContext.AudienceSizeConfig_AudienceSizeBin != null)
            {
                requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeBin = cmdletContext.AudienceSizeConfig_AudienceSizeBin;
            }
            if (requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeBin != null)
            {
                request.AudienceSizeConfig.AudienceSizeBins = requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeBin;
                requestAudienceSizeConfigIsNull = false;
            }
            Amazon.CleanRoomsML.AudienceSizeType requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeType = null;
            if (cmdletContext.AudienceSizeConfig_AudienceSizeType != null)
            {
                requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeType = cmdletContext.AudienceSizeConfig_AudienceSizeType;
            }
            if (requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeType != null)
            {
                request.AudienceSizeConfig.AudienceSizeType = requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeType;
                requestAudienceSizeConfigIsNull = false;
            }
             // determine if request.AudienceSizeConfig should be set to null
            if (requestAudienceSizeConfigIsNull)
            {
                request.AudienceSizeConfig = null;
            }
            if (cmdletContext.ChildResourceTagOnCreatePolicy != null)
            {
                request.ChildResourceTagOnCreatePolicy = cmdletContext.ChildResourceTagOnCreatePolicy;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MinMatchingSeedSize != null)
            {
                request.MinMatchingSeedSize = cmdletContext.MinMatchingSeedSize.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.CleanRoomsML.Model.ConfiguredAudienceModelOutputConfig();
            System.String requestOutputConfig_outputConfig_RoleArn = null;
            if (cmdletContext.OutputConfig_RoleArn != null)
            {
                requestOutputConfig_outputConfig_RoleArn = cmdletContext.OutputConfig_RoleArn;
            }
            if (requestOutputConfig_outputConfig_RoleArn != null)
            {
                request.OutputConfig.RoleArn = requestOutputConfig_outputConfig_RoleArn;
                requestOutputConfigIsNull = false;
            }
            Amazon.CleanRoomsML.Model.AudienceDestination requestOutputConfig_outputConfig_Destination = null;
            
             // populate Destination
            var requestOutputConfig_outputConfig_DestinationIsNull = true;
            requestOutputConfig_outputConfig_Destination = new Amazon.CleanRoomsML.Model.AudienceDestination();
            Amazon.CleanRoomsML.Model.S3ConfigMap requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination = null;
            
             // populate S3Destination
            var requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3DestinationIsNull = true;
            requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination = new Amazon.CleanRoomsML.Model.S3ConfigMap();
            System.String requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination_s3Destination_S3Uri = null;
            if (cmdletContext.S3Destination_S3Uri != null)
            {
                requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination_s3Destination_S3Uri = cmdletContext.S3Destination_S3Uri;
            }
            if (requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination_s3Destination_S3Uri != null)
            {
                requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination.S3Uri = requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination_s3Destination_S3Uri;
                requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3DestinationIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination should be set to null
            if (requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3DestinationIsNull)
            {
                requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination = null;
            }
            if (requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination != null)
            {
                requestOutputConfig_outputConfig_Destination.S3Destination = requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination;
                requestOutputConfig_outputConfig_DestinationIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_Destination should be set to null
            if (requestOutputConfig_outputConfig_DestinationIsNull)
            {
                requestOutputConfig_outputConfig_Destination = null;
            }
            if (requestOutputConfig_outputConfig_Destination != null)
            {
                request.OutputConfig.Destination = requestOutputConfig_outputConfig_Destination;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
            }
            if (cmdletContext.SharedAudienceMetric != null)
            {
                request.SharedAudienceMetrics = cmdletContext.SharedAudienceMetric;
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
        
        private Amazon.CleanRoomsML.Model.CreateConfiguredAudienceModelResponse CallAWSServiceOperation(IAmazonCleanRoomsML client, Amazon.CleanRoomsML.Model.CreateConfiguredAudienceModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CleanRoomsML", "CreateConfiguredAudienceModel");
            try
            {
                #if DESKTOP
                return client.CreateConfiguredAudienceModel(request);
                #elif CORECLR
                return client.CreateConfiguredAudienceModelAsync(request).GetAwaiter().GetResult();
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
            public System.String AudienceModelArn { get; set; }
            public List<System.Int32> AudienceSizeConfig_AudienceSizeBin { get; set; }
            public Amazon.CleanRoomsML.AudienceSizeType AudienceSizeConfig_AudienceSizeType { get; set; }
            public Amazon.CleanRoomsML.TagOnCreatePolicy ChildResourceTagOnCreatePolicy { get; set; }
            public System.String Description { get; set; }
            public System.Int32? MinMatchingSeedSize { get; set; }
            public System.String Name { get; set; }
            public System.String S3Destination_S3Uri { get; set; }
            public System.String OutputConfig_RoleArn { get; set; }
            public List<System.String> SharedAudienceMetric { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CleanRoomsML.Model.CreateConfiguredAudienceModelResponse, NewCRMLConfiguredAudienceModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfiguredAudienceModelArn;
        }
        
    }
}
