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
using Amazon.B2bi;
using Amazon.B2bi.Model;

namespace Amazon.PowerShell.Cmdlets.B2BI
{
    /// <summary>
    /// Parses the input EDI (electronic data interchange) file. The input file has a file
    /// size limit of 250 KB.
    /// </summary>
    [Cmdlet("Test", "B2BIParsing")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS B2B Data Interchange TestParsing API operation.", Operation = new[] {"TestParsing"}, SelectReturnType = typeof(Amazon.B2bi.Model.TestParsingResponse))]
    [AWSCmdletOutput("System.String or Amazon.B2bi.Model.TestParsingResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.B2bi.Model.TestParsingResponse) can be returned by specifying '-Select *'."
    )]
    public partial class TestB2BIParsingCmdlet : AmazonB2biClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InputFile_BucketName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputFile_BucketName { get; set; }
        #endregion
        
        #region Parameter FileFormat
        /// <summary>
        /// <para>
        /// <para>Specifies that the currently supported file formats for EDI transformations are <c>JSON</c>
        /// and <c>XML</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.B2bi.FileFormat")]
        public Amazon.B2bi.FileFormat FileFormat { get; set; }
        #endregion
        
        #region Parameter InputFile_Key
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 key for the file location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputFile_Key { get; set; }
        #endregion
        
        #region Parameter X12Details_TransactionSet
        /// <summary>
        /// <para>
        /// <para>Returns an enumerated type where each value identifies an X12 transaction set. Transaction
        /// sets are maintained by the X12 Accredited Standards Committee.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EdiType_X12Details_TransactionSet")]
        [AWSConstantClassSource("Amazon.B2bi.X12TransactionSet")]
        public Amazon.B2bi.X12TransactionSet X12Details_TransactionSet { get; set; }
        #endregion
        
        #region Parameter X12Details_Version
        /// <summary>
        /// <para>
        /// <para>Returns the version to use for the specified X12 transaction set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EdiType_X12Details_Version")]
        [AWSConstantClassSource("Amazon.B2bi.X12Version")]
        public Amazon.B2bi.X12Version X12Details_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ParsedFileContent'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.B2bi.Model.TestParsingResponse).
        /// Specifying the name of a property of type Amazon.B2bi.Model.TestParsingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ParsedFileContent";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.B2bi.Model.TestParsingResponse, TestB2BIParsingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.X12Details_TransactionSet = this.X12Details_TransactionSet;
            context.X12Details_Version = this.X12Details_Version;
            context.FileFormat = this.FileFormat;
            #if MODULAR
            if (this.FileFormat == null && ParameterWasBound(nameof(this.FileFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter FileFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputFile_BucketName = this.InputFile_BucketName;
            context.InputFile_Key = this.InputFile_Key;
            
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
            var request = new Amazon.B2bi.Model.TestParsingRequest();
            
            
             // populate EdiType
            var requestEdiTypeIsNull = true;
            request.EdiType = new Amazon.B2bi.Model.EdiType();
            Amazon.B2bi.Model.X12Details requestEdiType_ediType_X12Details = null;
            
             // populate X12Details
            var requestEdiType_ediType_X12DetailsIsNull = true;
            requestEdiType_ediType_X12Details = new Amazon.B2bi.Model.X12Details();
            Amazon.B2bi.X12TransactionSet requestEdiType_ediType_X12Details_x12Details_TransactionSet = null;
            if (cmdletContext.X12Details_TransactionSet != null)
            {
                requestEdiType_ediType_X12Details_x12Details_TransactionSet = cmdletContext.X12Details_TransactionSet;
            }
            if (requestEdiType_ediType_X12Details_x12Details_TransactionSet != null)
            {
                requestEdiType_ediType_X12Details.TransactionSet = requestEdiType_ediType_X12Details_x12Details_TransactionSet;
                requestEdiType_ediType_X12DetailsIsNull = false;
            }
            Amazon.B2bi.X12Version requestEdiType_ediType_X12Details_x12Details_Version = null;
            if (cmdletContext.X12Details_Version != null)
            {
                requestEdiType_ediType_X12Details_x12Details_Version = cmdletContext.X12Details_Version;
            }
            if (requestEdiType_ediType_X12Details_x12Details_Version != null)
            {
                requestEdiType_ediType_X12Details.Version = requestEdiType_ediType_X12Details_x12Details_Version;
                requestEdiType_ediType_X12DetailsIsNull = false;
            }
             // determine if requestEdiType_ediType_X12Details should be set to null
            if (requestEdiType_ediType_X12DetailsIsNull)
            {
                requestEdiType_ediType_X12Details = null;
            }
            if (requestEdiType_ediType_X12Details != null)
            {
                request.EdiType.X12Details = requestEdiType_ediType_X12Details;
                requestEdiTypeIsNull = false;
            }
             // determine if request.EdiType should be set to null
            if (requestEdiTypeIsNull)
            {
                request.EdiType = null;
            }
            if (cmdletContext.FileFormat != null)
            {
                request.FileFormat = cmdletContext.FileFormat;
            }
            
             // populate InputFile
            var requestInputFileIsNull = true;
            request.InputFile = new Amazon.B2bi.Model.S3Location();
            System.String requestInputFile_inputFile_BucketName = null;
            if (cmdletContext.InputFile_BucketName != null)
            {
                requestInputFile_inputFile_BucketName = cmdletContext.InputFile_BucketName;
            }
            if (requestInputFile_inputFile_BucketName != null)
            {
                request.InputFile.BucketName = requestInputFile_inputFile_BucketName;
                requestInputFileIsNull = false;
            }
            System.String requestInputFile_inputFile_Key = null;
            if (cmdletContext.InputFile_Key != null)
            {
                requestInputFile_inputFile_Key = cmdletContext.InputFile_Key;
            }
            if (requestInputFile_inputFile_Key != null)
            {
                request.InputFile.Key = requestInputFile_inputFile_Key;
                requestInputFileIsNull = false;
            }
             // determine if request.InputFile should be set to null
            if (requestInputFileIsNull)
            {
                request.InputFile = null;
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
        
        private Amazon.B2bi.Model.TestParsingResponse CallAWSServiceOperation(IAmazonB2bi client, Amazon.B2bi.Model.TestParsingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS B2B Data Interchange", "TestParsing");
            try
            {
                #if DESKTOP
                return client.TestParsing(request);
                #elif CORECLR
                return client.TestParsingAsync(request).GetAwaiter().GetResult();
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
            public Amazon.B2bi.X12TransactionSet X12Details_TransactionSet { get; set; }
            public Amazon.B2bi.X12Version X12Details_Version { get; set; }
            public Amazon.B2bi.FileFormat FileFormat { get; set; }
            public System.String InputFile_BucketName { get; set; }
            public System.String InputFile_Key { get; set; }
            public System.Func<Amazon.B2bi.Model.TestParsingResponse, TestB2BIParsingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ParsedFileContent;
        }
        
    }
}
