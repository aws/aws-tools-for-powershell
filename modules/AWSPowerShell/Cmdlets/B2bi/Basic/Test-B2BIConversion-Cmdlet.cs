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
using Amazon.B2bi;
using Amazon.B2bi.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.B2BI
{
    /// <summary>
    /// This operation mimics the latter half of a typical Outbound EDI request. It takes
    /// an input JSON/XML in the B2Bi shape as input, converts it to an X12 EDI string, and
    /// return that string.
    /// </summary>
    [Cmdlet("Test", "B2BIConversion")]
    [OutputType("Amazon.B2bi.Model.TestConversionResponse")]
    [AWSCmdlet("Calls the AWS B2B Data Interchange TestConversion API operation.", Operation = new[] {"TestConversion"}, SelectReturnType = typeof(Amazon.B2bi.Model.TestConversionResponse))]
    [AWSCmdletOutput("Amazon.B2bi.Model.TestConversionResponse",
        "This cmdlet returns an Amazon.B2bi.Model.TestConversionResponse object containing multiple properties."
    )]
    public partial class TestB2BIConversionCmdlet : AmazonB2biClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FileLocation_BucketName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_OutputSampleFile_FileLocation_BucketName")]
        public System.String FileLocation_BucketName { get; set; }
        #endregion
        
        #region Parameter InputFile_FileContent
        /// <summary>
        /// <para>
        /// <para>Specify the input contents, as a string, for the source of an outbound transformation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_InputFile_FileContent")]
        public System.String InputFile_FileContent { get; set; }
        #endregion
        
        #region Parameter Source_FileFormat
        /// <summary>
        /// <para>
        /// <para>The format for the input file: either JSON or XML.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.B2bi.ConversionSourceFormat")]
        public Amazon.B2bi.ConversionSourceFormat Source_FileFormat { get; set; }
        #endregion
        
        #region Parameter Target_FileFormat
        /// <summary>
        /// <para>
        /// <para>Currently, only X12 format is supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.B2bi.ConversionTargetFormat")]
        public Amazon.B2bi.ConversionTargetFormat Target_FileFormat { get; set; }
        #endregion
        
        #region Parameter FileLocation_Key
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 key for the file location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_OutputSampleFile_FileLocation_Key")]
        public System.String FileLocation_Key { get; set; }
        #endregion
        
        #region Parameter SplitOptions_SplitBy
        /// <summary>
        /// <para>
        /// <para>Specifies the method used to split X12 EDI files. Valid values include <c>TRANSACTION</c>
        /// (split by individual transaction sets), or <c>NONE</c> (no splitting).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_AdvancedOptions_X12_SplitOptions_SplitBy")]
        [AWSConstantClassSource("Amazon.B2bi.X12SplitBy")]
        public Amazon.B2bi.X12SplitBy SplitOptions_SplitBy { get; set; }
        #endregion
        
        #region Parameter X12_TransactionSet
        /// <summary>
        /// <para>
        /// <para>Returns an enumerated type where each value identifies an X12 transaction set. Transaction
        /// sets are maintained by the X12 Accredited Standards Committee.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_FormatDetails_X12_TransactionSet")]
        [AWSConstantClassSource("Amazon.B2bi.X12TransactionSet")]
        public Amazon.B2bi.X12TransactionSet X12_TransactionSet { get; set; }
        #endregion
        
        #region Parameter ValidationOptions_ValidationRule
        /// <summary>
        /// <para>
        /// <para>Specifies a list of validation rules to apply during EDI document processing. These
        /// rules can include code list modifications, element length constraints, and element
        /// requirement changes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_AdvancedOptions_X12_ValidationOptions_ValidationRules")]
        public Amazon.B2bi.Model.X12ValidationRule[] ValidationOptions_ValidationRule { get; set; }
        #endregion
        
        #region Parameter X12_Version
        /// <summary>
        /// <para>
        /// <para>Returns the version to use for the specified X12 transaction set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_FormatDetails_X12_Version")]
        [AWSConstantClassSource("Amazon.B2bi.X12Version")]
        public Amazon.B2bi.X12Version X12_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.B2bi.Model.TestConversionResponse).
        /// Specifying the name of a property of type Amazon.B2bi.Model.TestConversionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.B2bi.Model.TestConversionResponse, TestB2BIConversionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Source_FileFormat = this.Source_FileFormat;
            #if MODULAR
            if (this.Source_FileFormat == null && ParameterWasBound(nameof(this.Source_FileFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter Source_FileFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputFile_FileContent = this.InputFile_FileContent;
            context.SplitOptions_SplitBy = this.SplitOptions_SplitBy;
            if (this.ValidationOptions_ValidationRule != null)
            {
                context.ValidationOptions_ValidationRule = new List<Amazon.B2bi.Model.X12ValidationRule>(this.ValidationOptions_ValidationRule);
            }
            context.Target_FileFormat = this.Target_FileFormat;
            #if MODULAR
            if (this.Target_FileFormat == null && ParameterWasBound(nameof(this.Target_FileFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter Target_FileFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.X12_TransactionSet = this.X12_TransactionSet;
            context.X12_Version = this.X12_Version;
            context.FileLocation_BucketName = this.FileLocation_BucketName;
            context.FileLocation_Key = this.FileLocation_Key;
            
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
            var request = new Amazon.B2bi.Model.TestConversionRequest();
            
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.B2bi.Model.ConversionSource();
            Amazon.B2bi.ConversionSourceFormat requestSource_source_FileFormat = null;
            if (cmdletContext.Source_FileFormat != null)
            {
                requestSource_source_FileFormat = cmdletContext.Source_FileFormat;
            }
            if (requestSource_source_FileFormat != null)
            {
                request.Source.FileFormat = requestSource_source_FileFormat;
                requestSourceIsNull = false;
            }
            Amazon.B2bi.Model.InputFileSource requestSource_source_InputFile = null;
            
             // populate InputFile
            var requestSource_source_InputFileIsNull = true;
            requestSource_source_InputFile = new Amazon.B2bi.Model.InputFileSource();
            System.String requestSource_source_InputFile_inputFile_FileContent = null;
            if (cmdletContext.InputFile_FileContent != null)
            {
                requestSource_source_InputFile_inputFile_FileContent = cmdletContext.InputFile_FileContent;
            }
            if (requestSource_source_InputFile_inputFile_FileContent != null)
            {
                requestSource_source_InputFile.FileContent = requestSource_source_InputFile_inputFile_FileContent;
                requestSource_source_InputFileIsNull = false;
            }
             // determine if requestSource_source_InputFile should be set to null
            if (requestSource_source_InputFileIsNull)
            {
                requestSource_source_InputFile = null;
            }
            if (requestSource_source_InputFile != null)
            {
                request.Source.InputFile = requestSource_source_InputFile;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
            }
            
             // populate Target
            var requestTargetIsNull = true;
            request.Target = new Amazon.B2bi.Model.ConversionTarget();
            Amazon.B2bi.ConversionTargetFormat requestTarget_target_FileFormat = null;
            if (cmdletContext.Target_FileFormat != null)
            {
                requestTarget_target_FileFormat = cmdletContext.Target_FileFormat;
            }
            if (requestTarget_target_FileFormat != null)
            {
                request.Target.FileFormat = requestTarget_target_FileFormat;
                requestTargetIsNull = false;
            }
            Amazon.B2bi.Model.AdvancedOptions requestTarget_target_AdvancedOptions = null;
            
             // populate AdvancedOptions
            var requestTarget_target_AdvancedOptionsIsNull = true;
            requestTarget_target_AdvancedOptions = new Amazon.B2bi.Model.AdvancedOptions();
            Amazon.B2bi.Model.X12AdvancedOptions requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12 = null;
            
             // populate X12
            var requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12IsNull = true;
            requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12 = new Amazon.B2bi.Model.X12AdvancedOptions();
            Amazon.B2bi.Model.X12SplitOptions requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_SplitOptions = null;
            
             // populate SplitOptions
            var requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_SplitOptionsIsNull = true;
            requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_SplitOptions = new Amazon.B2bi.Model.X12SplitOptions();
            Amazon.B2bi.X12SplitBy requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_SplitOptions_splitOptions_SplitBy = null;
            if (cmdletContext.SplitOptions_SplitBy != null)
            {
                requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_SplitOptions_splitOptions_SplitBy = cmdletContext.SplitOptions_SplitBy;
            }
            if (requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_SplitOptions_splitOptions_SplitBy != null)
            {
                requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_SplitOptions.SplitBy = requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_SplitOptions_splitOptions_SplitBy;
                requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_SplitOptionsIsNull = false;
            }
             // determine if requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_SplitOptions should be set to null
            if (requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_SplitOptionsIsNull)
            {
                requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_SplitOptions = null;
            }
            if (requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_SplitOptions != null)
            {
                requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12.SplitOptions = requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_SplitOptions;
                requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12IsNull = false;
            }
            Amazon.B2bi.Model.X12ValidationOptions requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_ValidationOptions = null;
            
             // populate ValidationOptions
            var requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_ValidationOptionsIsNull = true;
            requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_ValidationOptions = new Amazon.B2bi.Model.X12ValidationOptions();
            List<Amazon.B2bi.Model.X12ValidationRule> requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_ValidationOptions_validationOptions_ValidationRule = null;
            if (cmdletContext.ValidationOptions_ValidationRule != null)
            {
                requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_ValidationOptions_validationOptions_ValidationRule = cmdletContext.ValidationOptions_ValidationRule;
            }
            if (requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_ValidationOptions_validationOptions_ValidationRule != null)
            {
                requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_ValidationOptions.ValidationRules = requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_ValidationOptions_validationOptions_ValidationRule;
                requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_ValidationOptionsIsNull = false;
            }
             // determine if requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_ValidationOptions should be set to null
            if (requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_ValidationOptionsIsNull)
            {
                requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_ValidationOptions = null;
            }
            if (requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_ValidationOptions != null)
            {
                requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12.ValidationOptions = requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12_target_AdvancedOptions_X12_ValidationOptions;
                requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12IsNull = false;
            }
             // determine if requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12 should be set to null
            if (requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12IsNull)
            {
                requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12 = null;
            }
            if (requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12 != null)
            {
                requestTarget_target_AdvancedOptions.X12 = requestTarget_target_AdvancedOptions_target_AdvancedOptions_X12;
                requestTarget_target_AdvancedOptionsIsNull = false;
            }
             // determine if requestTarget_target_AdvancedOptions should be set to null
            if (requestTarget_target_AdvancedOptionsIsNull)
            {
                requestTarget_target_AdvancedOptions = null;
            }
            if (requestTarget_target_AdvancedOptions != null)
            {
                request.Target.AdvancedOptions = requestTarget_target_AdvancedOptions;
                requestTargetIsNull = false;
            }
            Amazon.B2bi.Model.ConversionTargetFormatDetails requestTarget_target_FormatDetails = null;
            
             // populate FormatDetails
            var requestTarget_target_FormatDetailsIsNull = true;
            requestTarget_target_FormatDetails = new Amazon.B2bi.Model.ConversionTargetFormatDetails();
            Amazon.B2bi.Model.X12Details requestTarget_target_FormatDetails_target_FormatDetails_X12 = null;
            
             // populate X12
            var requestTarget_target_FormatDetails_target_FormatDetails_X12IsNull = true;
            requestTarget_target_FormatDetails_target_FormatDetails_X12 = new Amazon.B2bi.Model.X12Details();
            Amazon.B2bi.X12TransactionSet requestTarget_target_FormatDetails_target_FormatDetails_X12_x12_TransactionSet = null;
            if (cmdletContext.X12_TransactionSet != null)
            {
                requestTarget_target_FormatDetails_target_FormatDetails_X12_x12_TransactionSet = cmdletContext.X12_TransactionSet;
            }
            if (requestTarget_target_FormatDetails_target_FormatDetails_X12_x12_TransactionSet != null)
            {
                requestTarget_target_FormatDetails_target_FormatDetails_X12.TransactionSet = requestTarget_target_FormatDetails_target_FormatDetails_X12_x12_TransactionSet;
                requestTarget_target_FormatDetails_target_FormatDetails_X12IsNull = false;
            }
            Amazon.B2bi.X12Version requestTarget_target_FormatDetails_target_FormatDetails_X12_x12_Version = null;
            if (cmdletContext.X12_Version != null)
            {
                requestTarget_target_FormatDetails_target_FormatDetails_X12_x12_Version = cmdletContext.X12_Version;
            }
            if (requestTarget_target_FormatDetails_target_FormatDetails_X12_x12_Version != null)
            {
                requestTarget_target_FormatDetails_target_FormatDetails_X12.Version = requestTarget_target_FormatDetails_target_FormatDetails_X12_x12_Version;
                requestTarget_target_FormatDetails_target_FormatDetails_X12IsNull = false;
            }
             // determine if requestTarget_target_FormatDetails_target_FormatDetails_X12 should be set to null
            if (requestTarget_target_FormatDetails_target_FormatDetails_X12IsNull)
            {
                requestTarget_target_FormatDetails_target_FormatDetails_X12 = null;
            }
            if (requestTarget_target_FormatDetails_target_FormatDetails_X12 != null)
            {
                requestTarget_target_FormatDetails.X12 = requestTarget_target_FormatDetails_target_FormatDetails_X12;
                requestTarget_target_FormatDetailsIsNull = false;
            }
             // determine if requestTarget_target_FormatDetails should be set to null
            if (requestTarget_target_FormatDetailsIsNull)
            {
                requestTarget_target_FormatDetails = null;
            }
            if (requestTarget_target_FormatDetails != null)
            {
                request.Target.FormatDetails = requestTarget_target_FormatDetails;
                requestTargetIsNull = false;
            }
            Amazon.B2bi.Model.OutputSampleFileSource requestTarget_target_OutputSampleFile = null;
            
             // populate OutputSampleFile
            var requestTarget_target_OutputSampleFileIsNull = true;
            requestTarget_target_OutputSampleFile = new Amazon.B2bi.Model.OutputSampleFileSource();
            Amazon.B2bi.Model.S3Location requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation = null;
            
             // populate FileLocation
            var requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocationIsNull = true;
            requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation = new Amazon.B2bi.Model.S3Location();
            System.String requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation_fileLocation_BucketName = null;
            if (cmdletContext.FileLocation_BucketName != null)
            {
                requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation_fileLocation_BucketName = cmdletContext.FileLocation_BucketName;
            }
            if (requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation_fileLocation_BucketName != null)
            {
                requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation.BucketName = requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation_fileLocation_BucketName;
                requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocationIsNull = false;
            }
            System.String requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation_fileLocation_Key = null;
            if (cmdletContext.FileLocation_Key != null)
            {
                requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation_fileLocation_Key = cmdletContext.FileLocation_Key;
            }
            if (requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation_fileLocation_Key != null)
            {
                requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation.Key = requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation_fileLocation_Key;
                requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocationIsNull = false;
            }
             // determine if requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation should be set to null
            if (requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocationIsNull)
            {
                requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation = null;
            }
            if (requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation != null)
            {
                requestTarget_target_OutputSampleFile.FileLocation = requestTarget_target_OutputSampleFile_target_OutputSampleFile_FileLocation;
                requestTarget_target_OutputSampleFileIsNull = false;
            }
             // determine if requestTarget_target_OutputSampleFile should be set to null
            if (requestTarget_target_OutputSampleFileIsNull)
            {
                requestTarget_target_OutputSampleFile = null;
            }
            if (requestTarget_target_OutputSampleFile != null)
            {
                request.Target.OutputSampleFile = requestTarget_target_OutputSampleFile;
                requestTargetIsNull = false;
            }
             // determine if request.Target should be set to null
            if (requestTargetIsNull)
            {
                request.Target = null;
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
        
        private Amazon.B2bi.Model.TestConversionResponse CallAWSServiceOperation(IAmazonB2bi client, Amazon.B2bi.Model.TestConversionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS B2B Data Interchange", "TestConversion");
            try
            {
                return client.TestConversionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.B2bi.ConversionSourceFormat Source_FileFormat { get; set; }
            public System.String InputFile_FileContent { get; set; }
            public Amazon.B2bi.X12SplitBy SplitOptions_SplitBy { get; set; }
            public List<Amazon.B2bi.Model.X12ValidationRule> ValidationOptions_ValidationRule { get; set; }
            public Amazon.B2bi.ConversionTargetFormat Target_FileFormat { get; set; }
            public Amazon.B2bi.X12TransactionSet X12_TransactionSet { get; set; }
            public Amazon.B2bi.X12Version X12_Version { get; set; }
            public System.String FileLocation_BucketName { get; set; }
            public System.String FileLocation_Key { get; set; }
            public System.Func<Amazon.B2bi.Model.TestConversionResponse, TestB2BIConversionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
