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
using Amazon.ElasticInference;
using Amazon.ElasticInference.Model;

namespace Amazon.PowerShell.Cmdlets.EI
{
    /// <summary>
    /// <note><para>
    /// Amazon Elastic Inference is no longer available.
    /// </para></note><para>
    ///  Describes the locations in which a given accelerator type or set of types is present
    /// in a given region. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EIAcceleratorOffering")]
    [OutputType("Amazon.ElasticInference.Model.AcceleratorTypeOffering")]
    [AWSCmdlet("Calls the Amazon Elastic Inference DescribeAcceleratorOfferings API operation.", Operation = new[] {"DescribeAcceleratorOfferings"}, SelectReturnType = typeof(Amazon.ElasticInference.Model.DescribeAcceleratorOfferingsResponse))]
    [AWSCmdletOutput("Amazon.ElasticInference.Model.AcceleratorTypeOffering or Amazon.ElasticInference.Model.DescribeAcceleratorOfferingsResponse",
        "This cmdlet returns a collection of Amazon.ElasticInference.Model.AcceleratorTypeOffering objects.",
        "The service call response (type Amazon.ElasticInference.Model.DescribeAcceleratorOfferingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEIAcceleratorOfferingCmdlet : AmazonElasticInferenceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceleratorType
        /// <summary>
        /// <para>
        /// <para> The list of accelerator types to describe. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AcceleratorTypes")]
        public System.String[] AcceleratorType { get; set; }
        #endregion
        
        #region Parameter LocationType
        /// <summary>
        /// <para>
        /// <para> The location type that you want to describe accelerator type offerings for. It can
        /// assume the following values: region: will return the accelerator type offering at
        /// the regional level. availability-zone: will return the accelerator type offering at
        /// the availability zone level. availability-zone-id: will return the accelerator type
        /// offering at the availability zone level returning the availability zone id. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ElasticInference.LocationType")]
        public Amazon.ElasticInference.LocationType LocationType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AcceleratorTypeOfferings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticInference.Model.DescribeAcceleratorOfferingsResponse).
        /// Specifying the name of a property of type Amazon.ElasticInference.Model.DescribeAcceleratorOfferingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AcceleratorTypeOfferings";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LocationType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LocationType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LocationType' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.ElasticInference.Model.DescribeAcceleratorOfferingsResponse, GetEIAcceleratorOfferingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LocationType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AcceleratorType != null)
            {
                context.AcceleratorType = new List<System.String>(this.AcceleratorType);
            }
            context.LocationType = this.LocationType;
            #if MODULAR
            if (this.LocationType == null && ParameterWasBound(nameof(this.LocationType)))
            {
                WriteWarning("You are passing $null as a value for parameter LocationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticInference.Model.DescribeAcceleratorOfferingsRequest();
            
            if (cmdletContext.AcceleratorType != null)
            {
                request.AcceleratorTypes = cmdletContext.AcceleratorType;
            }
            if (cmdletContext.LocationType != null)
            {
                request.LocationType = cmdletContext.LocationType;
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
        
        private Amazon.ElasticInference.Model.DescribeAcceleratorOfferingsResponse CallAWSServiceOperation(IAmazonElasticInference client, Amazon.ElasticInference.Model.DescribeAcceleratorOfferingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Inference", "DescribeAcceleratorOfferings");
            try
            {
                #if DESKTOP
                return client.DescribeAcceleratorOfferings(request);
                #elif CORECLR
                return client.DescribeAcceleratorOfferingsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AcceleratorType { get; set; }
            public Amazon.ElasticInference.LocationType LocationType { get; set; }
            public System.Func<Amazon.ElasticInference.Model.DescribeAcceleratorOfferingsResponse, GetEIAcceleratorOfferingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AcceleratorTypeOfferings;
        }
        
    }
}
