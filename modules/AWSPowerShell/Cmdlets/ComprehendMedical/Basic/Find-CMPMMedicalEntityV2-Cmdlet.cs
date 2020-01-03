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
using Amazon.ComprehendMedical;
using Amazon.ComprehendMedical.Model;

namespace Amazon.PowerShell.Cmdlets.CMPM
{
    /// <summary>
    /// Inspects the clinical text for a variety of medical entities and returns specific
    /// information about them such as entity category, location, and confidence score on
    /// that information.
    /// 
    ///  
    /// <para>
    /// The <code>DetectEntitiesV2</code> operation replaces the <a>DetectEntities</a> operation.
    /// This new action uses a different model for determining the entities in your medical
    /// text and changes the way that some entities are returned in the output. You should
    /// use the <code>DetectEntitiesV2</code> operation in all new applications.
    /// </para><para>
    /// The <code>DetectEntitiesV2</code> operation returns the <code>Acuity</code> and <code>Direction</code>
    /// entities as attributes instead of types. 
    /// </para>
    /// </summary>
    [Cmdlet("Find", "CMPMMedicalEntityV2")]
    [OutputType("Amazon.ComprehendMedical.Model.Entity")]
    [AWSCmdlet("Calls the AWS Comprehend Medical DetectEntitiesV2 API operation.", Operation = new[] {"DetectEntitiesV2"}, SelectReturnType = typeof(Amazon.ComprehendMedical.Model.DetectEntitiesV2Response))]
    [AWSCmdletOutput("Amazon.ComprehendMedical.Model.Entity or Amazon.ComprehendMedical.Model.DetectEntitiesV2Response",
        "This cmdlet returns a collection of Amazon.ComprehendMedical.Model.Entity objects.",
        "The service call response (type Amazon.ComprehendMedical.Model.DetectEntitiesV2Response) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class FindCMPMMedicalEntityV2Cmdlet : AmazonComprehendMedicalClientCmdlet, IExecutor
    {
        
        #region Parameter Text
        /// <summary>
        /// <para>
        /// <para>A UTF-8 string containing the clinical content being examined for entities. Each string
        /// must contain fewer than 20,000 bytes of characters.</para>
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
        public System.String Text { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Entities'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComprehendMedical.Model.DetectEntitiesV2Response).
        /// Specifying the name of a property of type Amazon.ComprehendMedical.Model.DetectEntitiesV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Entities";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Text parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Text' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Text' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComprehendMedical.Model.DetectEntitiesV2Response, FindCMPMMedicalEntityV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Text;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Text = this.Text;
            #if MODULAR
            if (this.Text == null && ParameterWasBound(nameof(this.Text)))
            {
                WriteWarning("You are passing $null as a value for parameter Text which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ComprehendMedical.Model.DetectEntitiesV2Request();
            
            if (cmdletContext.Text != null)
            {
                request.Text = cmdletContext.Text;
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
        
        private Amazon.ComprehendMedical.Model.DetectEntitiesV2Response CallAWSServiceOperation(IAmazonComprehendMedical client, Amazon.ComprehendMedical.Model.DetectEntitiesV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Comprehend Medical", "DetectEntitiesV2");
            try
            {
                #if DESKTOP
                return client.DetectEntitiesV2(request);
                #elif CORECLR
                return client.DetectEntitiesV2Async(request).GetAwaiter().GetResult();
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
            public System.String Text { get; set; }
            public System.Func<Amazon.ComprehendMedical.Model.DetectEntitiesV2Response, FindCMPMMedicalEntityV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Entities;
        }
        
    }
}
