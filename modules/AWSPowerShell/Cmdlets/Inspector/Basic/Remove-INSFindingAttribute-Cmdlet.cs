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
using Amazon.Inspector;
using Amazon.Inspector.Model;

namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Removes entire attributes (key and value pairs) from the findings that are specified
    /// by the ARNs of the findings where an attribute with the specified key exists.
    /// </summary>
    [Cmdlet("Remove", "INSFindingAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Inspector RemoveAttributesFromFindings API operation.", Operation = new[] {"RemoveAttributesFromFindings"}, SelectReturnType = typeof(Amazon.Inspector.Model.RemoveAttributesFromFindingsResponse))]
    [AWSCmdletOutput("System.String or Amazon.Inspector.Model.RemoveAttributesFromFindingsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.Inspector.Model.RemoveAttributesFromFindingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveINSFindingAttributeCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeKey
        /// <summary>
        /// <para>
        /// <para>The array of attribute keys that you want to remove from specified findings.</para>
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
        [Alias("AttributeKeys")]
        public System.String[] AttributeKey { get; set; }
        #endregion
        
        #region Parameter FindingArn
        /// <summary>
        /// <para>
        /// <para>The ARNs that specify the findings that you want to remove attributes from.</para>
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
        [Alias("FindingArns")]
        public System.String[] FindingArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FailedItems'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector.Model.RemoveAttributesFromFindingsResponse).
        /// Specifying the name of a property of type Amazon.Inspector.Model.RemoveAttributesFromFindingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FailedItems";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FindingArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-INSFindingAttribute (RemoveAttributesFromFindings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector.Model.RemoveAttributesFromFindingsResponse, RemoveINSFindingAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AttributeKey != null)
            {
                context.AttributeKey = new List<System.String>(this.AttributeKey);
            }
            #if MODULAR
            if (this.AttributeKey == null && ParameterWasBound(nameof(this.AttributeKey)))
            {
                WriteWarning("You are passing $null as a value for parameter AttributeKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FindingArn != null)
            {
                context.FindingArn = new List<System.String>(this.FindingArn);
            }
            #if MODULAR
            if (this.FindingArn == null && ParameterWasBound(nameof(this.FindingArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FindingArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector.Model.RemoveAttributesFromFindingsRequest();
            
            if (cmdletContext.AttributeKey != null)
            {
                request.AttributeKeys = cmdletContext.AttributeKey;
            }
            if (cmdletContext.FindingArn != null)
            {
                request.FindingArns = cmdletContext.FindingArn;
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
        
        private Amazon.Inspector.Model.RemoveAttributesFromFindingsResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.RemoveAttributesFromFindingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Inspector", "RemoveAttributesFromFindings");
            try
            {
                #if DESKTOP
                return client.RemoveAttributesFromFindings(request);
                #elif CORECLR
                return client.RemoveAttributesFromFindingsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AttributeKey { get; set; }
            public List<System.String> FindingArn { get; set; }
            public System.Func<Amazon.Inspector.Model.RemoveAttributesFromFindingsResponse, RemoveINSFindingAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FailedItems;
        }
        
    }
}
