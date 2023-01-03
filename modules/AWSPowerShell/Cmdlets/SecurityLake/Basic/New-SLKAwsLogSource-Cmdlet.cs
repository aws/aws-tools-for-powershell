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
using Amazon.SecurityLake;
using Amazon.SecurityLake.Model;

namespace Amazon.PowerShell.Cmdlets.SLK
{
    /// <summary>
    /// Adds a natively supported Amazon Web Service as an Amazon Security Lake source. Enables
    /// source types for member accounts in required Amazon Web Services Regions, based on
    /// the parameters you specify. You can choose any source type in any Region for either
    /// accounts that are part of a trusted organization or standalone accounts. At least
    /// one of the three dimensions is a mandatory input to this API. However, you can supply
    /// any combination of the three dimensions to this API. 
    /// 
    ///  
    /// <para>
    /// By default, a dimension refers to the entire set. When you don't provide a dimension,
    /// Security Lake assumes that the missing dimension refers to the entire set. This is
    /// overridden when you supply any one of the inputs. For instance, when you do not specify
    /// members, the API enables all Security Lake member accounts for all sources. Similarly,
    /// when you do not specify Regions, Security Lake is enabled for all the Regions where
    /// Security Lake is available as a service.
    /// </para><para>
    /// You can use this API only to enable natively supported Amazon Web Services as a source.
    /// Use <code>CreateCustomLogSource</code> to enable data collection from a custom source.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("New", "SLKAwsLogSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityLake.Model.CreateAwsLogSourceResponse")]
    [AWSCmdlet("Calls the Amazon Security Lake CreateAwsLogSource API operation.", Operation = new[] {"CreateAwsLogSource"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.CreateAwsLogSourceResponse))]
    [AWSCmdletOutput("Amazon.SecurityLake.Model.CreateAwsLogSourceResponse",
        "This cmdlet returns an Amazon.SecurityLake.Model.CreateAwsLogSourceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSLKAwsLogSourceCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        #region Parameter EnableAllDimension
        /// <summary>
        /// <para>
        /// <para>Enables data collection from specific Amazon Web Services sources in all specific
        /// accounts and specific Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableAllDimensions")]
        public System.Collections.Hashtable EnableAllDimension { get; set; }
        #endregion
        
        #region Parameter EnableSingleDimension
        /// <summary>
        /// <para>
        /// <para>Enables data collection from all Amazon Web Services sources in specific accounts
        /// or Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EnableSingleDimension { get; set; }
        #endregion
        
        #region Parameter EnableTwoDimension
        /// <summary>
        /// <para>
        /// <para>Enables data collection from specific Amazon Web Services sources in specific accounts
        /// or Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableTwoDimensions")]
        public System.Collections.Hashtable EnableTwoDimension { get; set; }
        #endregion
        
        #region Parameter InputOrder
        /// <summary>
        /// <para>
        /// <para>Specifies the input order to enable dimensions in Security Lake, namely Region, source
        /// type, and member account.</para>
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
        public System.String[] InputOrder { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.CreateAwsLogSourceResponse).
        /// Specifying the name of a property of type Amazon.SecurityLake.Model.CreateAwsLogSourceResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InputOrder), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SLKAwsLogSource (CreateAwsLogSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.CreateAwsLogSourceResponse, NewSLKAwsLogSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.EnableAllDimension != null)
            {
                context.EnableAllDimension = new Dictionary<System.String, Dictionary<System.String, List<System.String>>>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnableAllDimension.Keys)
                {
                    context.EnableAllDimension.Add((String)hashKey, (Dictionary<String,List<String>>)(this.EnableAllDimension[hashKey]));
                }
            }
            if (this.EnableSingleDimension != null)
            {
                context.EnableSingleDimension = new List<System.String>(this.EnableSingleDimension);
            }
            if (this.EnableTwoDimension != null)
            {
                context.EnableTwoDimension = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnableTwoDimension.Keys)
                {
                    object hashValue = this.EnableTwoDimension[hashKey];
                    if (hashValue == null)
                    {
                        context.EnableTwoDimension.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.EnableTwoDimension.Add((String)hashKey, valueSet);
                }
            }
            if (this.InputOrder != null)
            {
                context.InputOrder = new List<System.String>(this.InputOrder);
            }
            #if MODULAR
            if (this.InputOrder == null && ParameterWasBound(nameof(this.InputOrder)))
            {
                WriteWarning("You are passing $null as a value for parameter InputOrder which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityLake.Model.CreateAwsLogSourceRequest();
            
            if (cmdletContext.EnableAllDimension != null)
            {
                request.EnableAllDimensions = cmdletContext.EnableAllDimension;
            }
            if (cmdletContext.EnableSingleDimension != null)
            {
                request.EnableSingleDimension = cmdletContext.EnableSingleDimension;
            }
            if (cmdletContext.EnableTwoDimension != null)
            {
                request.EnableTwoDimensions = cmdletContext.EnableTwoDimension;
            }
            if (cmdletContext.InputOrder != null)
            {
                request.InputOrder = cmdletContext.InputOrder;
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
        
        private Amazon.SecurityLake.Model.CreateAwsLogSourceResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.CreateAwsLogSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "CreateAwsLogSource");
            try
            {
                #if DESKTOP
                return client.CreateAwsLogSource(request);
                #elif CORECLR
                return client.CreateAwsLogSourceAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Dictionary<System.String, List<System.String>>> EnableAllDimension { get; set; }
            public List<System.String> EnableSingleDimension { get; set; }
            public Dictionary<System.String, List<System.String>> EnableTwoDimension { get; set; }
            public List<System.String> InputOrder { get; set; }
            public System.Func<Amazon.SecurityLake.Model.CreateAwsLogSourceResponse, NewSLKAwsLogSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
