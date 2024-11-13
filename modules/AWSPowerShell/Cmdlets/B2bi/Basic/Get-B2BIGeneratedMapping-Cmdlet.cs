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
    /// Takes sample input and output documents and uses Amazon Bedrock to generate a mapping
    /// automatically. Depending on the accuracy and other factors, you can then edit the
    /// mapping for your needs.
    /// 
    ///  <note><para>
    /// Before you can use the AI-assisted feature for Amazon Web Services B2B Data Interchange
    /// you must enable models in Amazon Bedrock. For details, see <a href="https://docs.aws.amazon.com/b2bi/latest/userguide/ai-assisted-mapping.html#ai-assist-prereq">AI-assisted
    /// template mapping prerequisites</a> in the <i>Amazon Web Services B2B Data Interchange
    /// User guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "B2BIGeneratedMapping")]
    [OutputType("Amazon.B2bi.Model.GenerateMappingResponse")]
    [AWSCmdlet("Calls the AWS B2B Data Interchange GenerateMapping API operation.", Operation = new[] {"GenerateMapping"}, SelectReturnType = typeof(Amazon.B2bi.Model.GenerateMappingResponse))]
    [AWSCmdletOutput("Amazon.B2bi.Model.GenerateMappingResponse",
        "This cmdlet returns an Amazon.B2bi.Model.GenerateMappingResponse object containing multiple properties."
    )]
    public partial class GetB2BIGeneratedMappingCmdlet : AmazonB2biClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InputFileContent
        /// <summary>
        /// <para>
        /// <para>Provide the contents of a sample X12 EDI file (for inbound EDI) or JSON/XML file (for
        /// outbound EDI) to use as a starting point for the mapping.</para>
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
        public System.String InputFileContent { get; set; }
        #endregion
        
        #region Parameter MappingType
        /// <summary>
        /// <para>
        /// <para>Specify the mapping type: either <c>JSONATA</c> or <c>XSLT.</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.B2bi.MappingType")]
        public Amazon.B2bi.MappingType MappingType { get; set; }
        #endregion
        
        #region Parameter OutputFileContent
        /// <summary>
        /// <para>
        /// <para>Provide the contents of a sample X12 EDI file (for outbound EDI) or JSON/XML file
        /// (for inbound EDI) to use as a target for the mapping.</para>
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
        public System.String OutputFileContent { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.B2bi.Model.GenerateMappingResponse).
        /// Specifying the name of a property of type Amazon.B2bi.Model.GenerateMappingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.B2bi.Model.GenerateMappingResponse, GetB2BIGeneratedMappingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InputFileContent = this.InputFileContent;
            #if MODULAR
            if (this.InputFileContent == null && ParameterWasBound(nameof(this.InputFileContent)))
            {
                WriteWarning("You are passing $null as a value for parameter InputFileContent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MappingType = this.MappingType;
            #if MODULAR
            if (this.MappingType == null && ParameterWasBound(nameof(this.MappingType)))
            {
                WriteWarning("You are passing $null as a value for parameter MappingType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputFileContent = this.OutputFileContent;
            #if MODULAR
            if (this.OutputFileContent == null && ParameterWasBound(nameof(this.OutputFileContent)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputFileContent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.B2bi.Model.GenerateMappingRequest();
            
            if (cmdletContext.InputFileContent != null)
            {
                request.InputFileContent = cmdletContext.InputFileContent;
            }
            if (cmdletContext.MappingType != null)
            {
                request.MappingType = cmdletContext.MappingType;
            }
            if (cmdletContext.OutputFileContent != null)
            {
                request.OutputFileContent = cmdletContext.OutputFileContent;
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
        
        private Amazon.B2bi.Model.GenerateMappingResponse CallAWSServiceOperation(IAmazonB2bi client, Amazon.B2bi.Model.GenerateMappingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS B2B Data Interchange", "GenerateMapping");
            try
            {
                #if DESKTOP
                return client.GenerateMapping(request);
                #elif CORECLR
                return client.GenerateMappingAsync(request).GetAwaiter().GetResult();
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
            public System.String InputFileContent { get; set; }
            public Amazon.B2bi.MappingType MappingType { get; set; }
            public System.String OutputFileContent { get; set; }
            public System.Func<Amazon.B2bi.Model.GenerateMappingResponse, GetB2BIGeneratedMappingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
