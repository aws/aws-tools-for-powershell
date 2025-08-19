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
using Amazon.MedicalImaging;
using Amazon.MedicalImaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MIS
{
    /// <summary>
    /// Update image set metadata attributes.
    /// </summary>
    [Cmdlet("Update", "MISImageSetMetadata", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MedicalImaging.Model.UpdateImageSetMetadataResponse")]
    [AWSCmdlet("Calls the Amazon Medical Imaging Service UpdateImageSetMetadata API operation.", Operation = new[] {"UpdateImageSetMetadata"}, SelectReturnType = typeof(Amazon.MedicalImaging.Model.UpdateImageSetMetadataResponse))]
    [AWSCmdletOutput("Amazon.MedicalImaging.Model.UpdateImageSetMetadataResponse",
        "This cmdlet returns an Amazon.MedicalImaging.Model.UpdateImageSetMetadataResponse object containing multiple properties."
    )]
    public partial class UpdateMISImageSetMetadataCmdlet : AmazonMedicalImagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DatastoreId
        /// <summary>
        /// <para>
        /// <para>The data store identifier.</para>
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
        public System.String DatastoreId { get; set; }
        #endregion
        
        #region Parameter ForceUpdate
        /// <summary>
        /// <para>
        /// <para>Setting this flag will force the <c>UpdateImageSetMetadata</c> operation for the following
        /// attributes:</para><ul><li><para><c>Tag.StudyInstanceUID</c>, <c>Tag.SeriesInstanceUID</c>, <c>Tag.SOPInstanceUID</c>,
        /// and <c>Tag.StudyID</c></para></li><li><para>Adding, removing, or updating private tags for an individual SOP Instance</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceUpdate { get; set; }
        #endregion
        
        #region Parameter ImageSetId
        /// <summary>
        /// <para>
        /// <para>The image set identifier.</para>
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
        public System.String ImageSetId { get; set; }
        #endregion
        
        #region Parameter LatestVersionId
        /// <summary>
        /// <para>
        /// <para>The latest image set version identifier.</para>
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
        public System.String LatestVersionId { get; set; }
        #endregion
        
        #region Parameter DICOMUpdates_RemovableAttribute
        /// <summary>
        /// <para>
        /// <para>The DICOM tags to be removed from <c>ImageSetMetadata</c>.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateImageSetMetadataUpdates_DICOMUpdates_RemovableAttributes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] DICOMUpdates_RemovableAttribute { get; set; }
        #endregion
        
        #region Parameter UpdateImageSetMetadataUpdates_RevertToVersionId
        /// <summary>
        /// <para>
        /// <para>Specifies the previous image set version ID to revert the current image set back to.</para><note><para>You must provide either <c>revertToVersionId</c> or <c>DICOMUpdates</c> in your request.
        /// A <c>ValidationException</c> error is thrown if both parameters are provided at the
        /// same time.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdateImageSetMetadataUpdates_RevertToVersionId { get; set; }
        #endregion
        
        #region Parameter DICOMUpdates_UpdatableAttribute
        /// <summary>
        /// <para>
        /// <para>The DICOM tags that need to be updated in <c>ImageSetMetadata</c>.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateImageSetMetadataUpdates_DICOMUpdates_UpdatableAttributes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] DICOMUpdates_UpdatableAttribute { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MedicalImaging.Model.UpdateImageSetMetadataResponse).
        /// Specifying the name of a property of type Amazon.MedicalImaging.Model.UpdateImageSetMetadataResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImageSetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MISImageSetMetadata (UpdateImageSetMetadata)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MedicalImaging.Model.UpdateImageSetMetadataResponse, UpdateMISImageSetMetadataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatastoreId = this.DatastoreId;
            #if MODULAR
            if (this.DatastoreId == null && ParameterWasBound(nameof(this.DatastoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatastoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ForceUpdate = this.ForceUpdate;
            context.ImageSetId = this.ImageSetId;
            #if MODULAR
            if (this.ImageSetId == null && ParameterWasBound(nameof(this.ImageSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LatestVersionId = this.LatestVersionId;
            #if MODULAR
            if (this.LatestVersionId == null && ParameterWasBound(nameof(this.LatestVersionId)))
            {
                WriteWarning("You are passing $null as a value for parameter LatestVersionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DICOMUpdates_RemovableAttribute = this.DICOMUpdates_RemovableAttribute;
            context.DICOMUpdates_UpdatableAttribute = this.DICOMUpdates_UpdatableAttribute;
            context.UpdateImageSetMetadataUpdates_RevertToVersionId = this.UpdateImageSetMetadataUpdates_RevertToVersionId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _DICOMUpdates_RemovableAttributeStream = null;
            System.IO.MemoryStream _DICOMUpdates_UpdatableAttributeStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.MedicalImaging.Model.UpdateImageSetMetadataRequest();
                
                if (cmdletContext.DatastoreId != null)
                {
                    request.DatastoreId = cmdletContext.DatastoreId;
                }
                if (cmdletContext.ForceUpdate != null)
                {
                    request.Force = cmdletContext.ForceUpdate.Value;
                }
                if (cmdletContext.ImageSetId != null)
                {
                    request.ImageSetId = cmdletContext.ImageSetId;
                }
                if (cmdletContext.LatestVersionId != null)
                {
                    request.LatestVersionId = cmdletContext.LatestVersionId;
                }
                
                 // populate UpdateImageSetMetadataUpdates
                request.UpdateImageSetMetadataUpdates = new Amazon.MedicalImaging.Model.MetadataUpdates();
                System.String requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_RevertToVersionId = null;
                if (cmdletContext.UpdateImageSetMetadataUpdates_RevertToVersionId != null)
                {
                    requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_RevertToVersionId = cmdletContext.UpdateImageSetMetadataUpdates_RevertToVersionId;
                }
                if (requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_RevertToVersionId != null)
                {
                    request.UpdateImageSetMetadataUpdates.RevertToVersionId = requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_RevertToVersionId;
                }
                Amazon.MedicalImaging.Model.DICOMUpdates requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates = null;
                
                 // populate DICOMUpdates
                var requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdatesIsNull = true;
                requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates = new Amazon.MedicalImaging.Model.DICOMUpdates();
                System.IO.MemoryStream requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates_dICOMUpdates_RemovableAttribute = null;
                if (cmdletContext.DICOMUpdates_RemovableAttribute != null)
                {
                    _DICOMUpdates_RemovableAttributeStream = new System.IO.MemoryStream(cmdletContext.DICOMUpdates_RemovableAttribute);
                    requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates_dICOMUpdates_RemovableAttribute = _DICOMUpdates_RemovableAttributeStream;
                }
                if (requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates_dICOMUpdates_RemovableAttribute != null)
                {
                    requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates.RemovableAttributes = requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates_dICOMUpdates_RemovableAttribute;
                    requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdatesIsNull = false;
                }
                System.IO.MemoryStream requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates_dICOMUpdates_UpdatableAttribute = null;
                if (cmdletContext.DICOMUpdates_UpdatableAttribute != null)
                {
                    _DICOMUpdates_UpdatableAttributeStream = new System.IO.MemoryStream(cmdletContext.DICOMUpdates_UpdatableAttribute);
                    requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates_dICOMUpdates_UpdatableAttribute = _DICOMUpdates_UpdatableAttributeStream;
                }
                if (requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates_dICOMUpdates_UpdatableAttribute != null)
                {
                    requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates.UpdatableAttributes = requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates_dICOMUpdates_UpdatableAttribute;
                    requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdatesIsNull = false;
                }
                 // determine if requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates should be set to null
                if (requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdatesIsNull)
                {
                    requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates = null;
                }
                if (requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates != null)
                {
                    request.UpdateImageSetMetadataUpdates.DICOMUpdates = requestUpdateImageSetMetadataUpdates_updateImageSetMetadataUpdates_DICOMUpdates;
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
            finally
            {
                if( _DICOMUpdates_RemovableAttributeStream != null)
                {
                    _DICOMUpdates_RemovableAttributeStream.Dispose();
                }
                if( _DICOMUpdates_UpdatableAttributeStream != null)
                {
                    _DICOMUpdates_UpdatableAttributeStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.MedicalImaging.Model.UpdateImageSetMetadataResponse CallAWSServiceOperation(IAmazonMedicalImaging client, Amazon.MedicalImaging.Model.UpdateImageSetMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Medical Imaging Service", "UpdateImageSetMetadata");
            try
            {
                return client.UpdateImageSetMetadataAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DatastoreId { get; set; }
            public System.Boolean? ForceUpdate { get; set; }
            public System.String ImageSetId { get; set; }
            public System.String LatestVersionId { get; set; }
            public byte[] DICOMUpdates_RemovableAttribute { get; set; }
            public byte[] DICOMUpdates_UpdatableAttribute { get; set; }
            public System.String UpdateImageSetMetadataUpdates_RevertToVersionId { get; set; }
            public System.Func<Amazon.MedicalImaging.Model.UpdateImageSetMetadataResponse, UpdateMISImageSetMetadataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
