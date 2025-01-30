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
using Amazon.Inspector;
using Amazon.Inspector.Model;

namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Describes the exclusions that are specified by the exclusions' ARNs.
    /// </summary>
    [Cmdlet("Get", "INSExclusion")]
    [OutputType("Amazon.Inspector.Model.DescribeExclusionsResponse")]
    [AWSCmdlet("Calls the Amazon Inspector DescribeExclusions API operation.", Operation = new[] {"DescribeExclusions"}, SelectReturnType = typeof(Amazon.Inspector.Model.DescribeExclusionsResponse))]
    [AWSCmdletOutput("Amazon.Inspector.Model.DescribeExclusionsResponse",
        "This cmdlet returns an Amazon.Inspector.Model.DescribeExclusionsResponse object containing multiple properties."
    )]
    public partial class GetINSExclusionCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExclusionArn
        /// <summary>
        /// <para>
        /// <para>The list of ARNs that specify the exclusions that you want to describe.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ExclusionArns")]
        public System.String[] ExclusionArn { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The locale into which you want to translate the exclusion's title, description, and
        /// recommendation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector.Locale")]
        public Amazon.Inspector.Locale Locale { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector.Model.DescribeExclusionsResponse).
        /// Specifying the name of a property of type Amazon.Inspector.Model.DescribeExclusionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ExclusionArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ExclusionArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ExclusionArn' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Inspector.Model.DescribeExclusionsResponse, GetINSExclusionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ExclusionArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ExclusionArn != null)
            {
                context.ExclusionArn = new List<System.String>(this.ExclusionArn);
            }
            #if MODULAR
            if (this.ExclusionArn == null && ParameterWasBound(nameof(this.ExclusionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExclusionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Locale = this.Locale;
            
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
            var request = new Amazon.Inspector.Model.DescribeExclusionsRequest();
            
            if (cmdletContext.ExclusionArn != null)
            {
                request.ExclusionArns = cmdletContext.ExclusionArn;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
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
        
        private Amazon.Inspector.Model.DescribeExclusionsResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.DescribeExclusionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Inspector", "DescribeExclusions");
            try
            {
                #if DESKTOP
                return client.DescribeExclusions(request);
                #elif CORECLR
                return client.DescribeExclusionsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ExclusionArn { get; set; }
            public Amazon.Inspector.Locale Locale { get; set; }
            public System.Func<Amazon.Inspector.Model.DescribeExclusionsResponse, GetINSExclusionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
