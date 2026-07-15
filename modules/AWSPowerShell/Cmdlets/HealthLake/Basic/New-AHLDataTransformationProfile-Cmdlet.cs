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
using Amazon.HealthLake;
using Amazon.HealthLake.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AHL
{
    /// <summary>
    /// Creates a data transformation profile in DRAFT state. Specify a built-in starter profile,
    /// an existing profile version, raw profile content, or a sample data file as the source.
    /// </summary>
    [Cmdlet("New", "AHLDataTransformationProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.HealthLake.Model.CreateDataTransformationProfileResponse")]
    [AWSCmdlet("Calls the Amazon HealthLake CreateDataTransformationProfile API operation.", Operation = new[] {"CreateDataTransformationProfile"}, SelectReturnType = typeof(Amazon.HealthLake.Model.CreateDataTransformationProfileResponse))]
    [AWSCmdletOutput("Amazon.HealthLake.Model.CreateDataTransformationProfileResponse",
        "This cmdlet returns an Amazon.HealthLake.Model.CreateDataTransformationProfileResponse object containing multiple properties."
    )]
    public partial class NewAHLDataTransformationProfileCmdlet : AmazonHealthLakeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS Key Management Service (AWS KMS) key identifier used to encrypt the profile
        /// content at rest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ProfileDescription
        /// <summary>
        /// <para>
        /// <para>A human-readable description of the profile's purpose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProfileDescription { get; set; }
        #endregion
        
        #region Parameter Source_ExistingVersionedProfileId_ProfileId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the existing profile to clone from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_ExistingVersionedProfileId_ProfileId { get; set; }
        #endregion
        
        #region Parameter Source_ProfileMapping_ProfileMapping
        /// <summary>
        /// <para>
        /// <para>The content as a map of file paths to profile strings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Source_ProfileMapping_ProfileMapping { get; set; }
        #endregion
        
        #region Parameter Profile
        /// <summary>
        /// <para>
        /// <para>A name for the data transformation profile.</para>
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
        public System.String Profile { get; set; }
        #endregion
        
        #region Parameter Source_SampleData_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI of the sample data file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_SampleData_S3Uri { get; set; }
        #endregion
        
        #region Parameter SourceFormat
        /// <summary>
        /// <para>
        /// <para>The source data format that this profile converts from (Consolidated Clinical Document
        /// Architecture (C-CDA) or Comma-separated values (CSV)).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.HealthLake.SourceFormat")]
        public Amazon.HealthLake.SourceFormat SourceFormat { get; set; }
        #endregion
        
        #region Parameter Source_StarterProfile_StarterProfileName
        /// <summary>
        /// <para>
        /// <para>The name of the built-in starter profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_StarterProfile_StarterProfileName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the profile at creation time.</para><para />
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
        
        #region Parameter Source_ExistingVersionedProfileId_Version
        /// <summary>
        /// <para>
        /// <para>The version number of the existing profile to clone from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Source_ExistingVersionedProfileId_Version { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, the service ignores the request
        /// but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.HealthLake.Model.CreateDataTransformationProfileResponse).
        /// Specifying the name of a property of type Amazon.HealthLake.Model.CreateDataTransformationProfileResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AHLDataTransformationProfile (CreateDataTransformationProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.HealthLake.Model.CreateDataTransformationProfileResponse, NewAHLDataTransformationProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.KmsKeyId = this.KmsKeyId;
            context.ProfileDescription = this.ProfileDescription;
            context.Profile = this.Profile;
            #if MODULAR
            if (this.Profile == null && ParameterWasBound(nameof(this.Profile)))
            {
                WriteWarning("You are passing $null as a value for parameter Profile which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Source_ExistingVersionedProfileId_ProfileId = this.Source_ExistingVersionedProfileId_ProfileId;
            context.Source_ExistingVersionedProfileId_Version = this.Source_ExistingVersionedProfileId_Version;
            if (this.Source_ProfileMapping_ProfileMapping != null)
            {
                context.Source_ProfileMapping_ProfileMapping = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Source_ProfileMapping_ProfileMapping.Keys)
                {
                    context.Source_ProfileMapping_ProfileMapping.Add((String)hashKey, (System.String)(this.Source_ProfileMapping_ProfileMapping[hashKey]));
                }
            }
            context.Source_SampleData_S3Uri = this.Source_SampleData_S3Uri;
            context.Source_StarterProfile_StarterProfileName = this.Source_StarterProfile_StarterProfileName;
            context.SourceFormat = this.SourceFormat;
            #if MODULAR
            if (this.SourceFormat == null && ParameterWasBound(nameof(this.SourceFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.HealthLake.Model.CreateDataTransformationProfileRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.ProfileDescription != null)
            {
                request.ProfileDescription = cmdletContext.ProfileDescription;
            }
            if (cmdletContext.Profile != null)
            {
                request.ProfileName = cmdletContext.Profile;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.HealthLake.Model.CreateDataTransformationProfileSource();
            Amazon.HealthLake.Model.ProfileMappingSource requestSource_source_ProfileMapping = null;
            
             // populate ProfileMapping
            var requestSource_source_ProfileMappingIsNull = true;
            requestSource_source_ProfileMapping = new Amazon.HealthLake.Model.ProfileMappingSource();
            Dictionary<System.String, System.String> requestSource_source_ProfileMapping_source_ProfileMapping_ProfileMapping = null;
            if (cmdletContext.Source_ProfileMapping_ProfileMapping != null)
            {
                requestSource_source_ProfileMapping_source_ProfileMapping_ProfileMapping = cmdletContext.Source_ProfileMapping_ProfileMapping;
            }
            if (requestSource_source_ProfileMapping_source_ProfileMapping_ProfileMapping != null)
            {
                requestSource_source_ProfileMapping.ProfileMapping = requestSource_source_ProfileMapping_source_ProfileMapping_ProfileMapping;
                requestSource_source_ProfileMappingIsNull = false;
            }
             // determine if requestSource_source_ProfileMapping should be set to null
            if (requestSource_source_ProfileMappingIsNull)
            {
                requestSource_source_ProfileMapping = null;
            }
            if (requestSource_source_ProfileMapping != null)
            {
                request.Source.ProfileMapping = requestSource_source_ProfileMapping;
                requestSourceIsNull = false;
            }
            Amazon.HealthLake.Model.SampleDataSource requestSource_source_SampleData = null;
            
             // populate SampleData
            var requestSource_source_SampleDataIsNull = true;
            requestSource_source_SampleData = new Amazon.HealthLake.Model.SampleDataSource();
            System.String requestSource_source_SampleData_source_SampleData_S3Uri = null;
            if (cmdletContext.Source_SampleData_S3Uri != null)
            {
                requestSource_source_SampleData_source_SampleData_S3Uri = cmdletContext.Source_SampleData_S3Uri;
            }
            if (requestSource_source_SampleData_source_SampleData_S3Uri != null)
            {
                requestSource_source_SampleData.S3Uri = requestSource_source_SampleData_source_SampleData_S3Uri;
                requestSource_source_SampleDataIsNull = false;
            }
             // determine if requestSource_source_SampleData should be set to null
            if (requestSource_source_SampleDataIsNull)
            {
                requestSource_source_SampleData = null;
            }
            if (requestSource_source_SampleData != null)
            {
                request.Source.SampleData = requestSource_source_SampleData;
                requestSourceIsNull = false;
            }
            Amazon.HealthLake.Model.StarterProfileSource requestSource_source_StarterProfile = null;
            
             // populate StarterProfile
            var requestSource_source_StarterProfileIsNull = true;
            requestSource_source_StarterProfile = new Amazon.HealthLake.Model.StarterProfileSource();
            System.String requestSource_source_StarterProfile_source_StarterProfile_StarterProfileName = null;
            if (cmdletContext.Source_StarterProfile_StarterProfileName != null)
            {
                requestSource_source_StarterProfile_source_StarterProfile_StarterProfileName = cmdletContext.Source_StarterProfile_StarterProfileName;
            }
            if (requestSource_source_StarterProfile_source_StarterProfile_StarterProfileName != null)
            {
                requestSource_source_StarterProfile.StarterProfileName = requestSource_source_StarterProfile_source_StarterProfile_StarterProfileName;
                requestSource_source_StarterProfileIsNull = false;
            }
             // determine if requestSource_source_StarterProfile should be set to null
            if (requestSource_source_StarterProfileIsNull)
            {
                requestSource_source_StarterProfile = null;
            }
            if (requestSource_source_StarterProfile != null)
            {
                request.Source.StarterProfile = requestSource_source_StarterProfile;
                requestSourceIsNull = false;
            }
            Amazon.HealthLake.Model.ExistingVersionedProfileSource requestSource_source_ExistingVersionedProfileId = null;
            
             // populate ExistingVersionedProfileId
            var requestSource_source_ExistingVersionedProfileIdIsNull = true;
            requestSource_source_ExistingVersionedProfileId = new Amazon.HealthLake.Model.ExistingVersionedProfileSource();
            System.String requestSource_source_ExistingVersionedProfileId_source_ExistingVersionedProfileId_ProfileId = null;
            if (cmdletContext.Source_ExistingVersionedProfileId_ProfileId != null)
            {
                requestSource_source_ExistingVersionedProfileId_source_ExistingVersionedProfileId_ProfileId = cmdletContext.Source_ExistingVersionedProfileId_ProfileId;
            }
            if (requestSource_source_ExistingVersionedProfileId_source_ExistingVersionedProfileId_ProfileId != null)
            {
                requestSource_source_ExistingVersionedProfileId.ProfileId = requestSource_source_ExistingVersionedProfileId_source_ExistingVersionedProfileId_ProfileId;
                requestSource_source_ExistingVersionedProfileIdIsNull = false;
            }
            System.Int32? requestSource_source_ExistingVersionedProfileId_source_ExistingVersionedProfileId_Version = null;
            if (cmdletContext.Source_ExistingVersionedProfileId_Version != null)
            {
                requestSource_source_ExistingVersionedProfileId_source_ExistingVersionedProfileId_Version = cmdletContext.Source_ExistingVersionedProfileId_Version.Value;
            }
            if (requestSource_source_ExistingVersionedProfileId_source_ExistingVersionedProfileId_Version != null)
            {
                requestSource_source_ExistingVersionedProfileId.Version = requestSource_source_ExistingVersionedProfileId_source_ExistingVersionedProfileId_Version.Value;
                requestSource_source_ExistingVersionedProfileIdIsNull = false;
            }
             // determine if requestSource_source_ExistingVersionedProfileId should be set to null
            if (requestSource_source_ExistingVersionedProfileIdIsNull)
            {
                requestSource_source_ExistingVersionedProfileId = null;
            }
            if (requestSource_source_ExistingVersionedProfileId != null)
            {
                request.Source.ExistingVersionedProfileId = requestSource_source_ExistingVersionedProfileId;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
            }
            if (cmdletContext.SourceFormat != null)
            {
                request.SourceFormat = cmdletContext.SourceFormat;
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
        
        private Amazon.HealthLake.Model.CreateDataTransformationProfileResponse CallAWSServiceOperation(IAmazonHealthLake client, Amazon.HealthLake.Model.CreateDataTransformationProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon HealthLake", "CreateDataTransformationProfile");
            try
            {
                return client.CreateDataTransformationProfileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String ProfileDescription { get; set; }
            public System.String Profile { get; set; }
            public System.String Source_ExistingVersionedProfileId_ProfileId { get; set; }
            public System.Int32? Source_ExistingVersionedProfileId_Version { get; set; }
            public Dictionary<System.String, System.String> Source_ProfileMapping_ProfileMapping { get; set; }
            public System.String Source_SampleData_S3Uri { get; set; }
            public System.String Source_StarterProfile_StarterProfileName { get; set; }
            public Amazon.HealthLake.SourceFormat SourceFormat { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.HealthLake.Model.CreateDataTransformationProfileResponse, NewAHLDataTransformationProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
