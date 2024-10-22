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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Allows or restricts mirroring network services.
    /// 
    ///  
    /// <para>
    ///  By default, Amazon DNS network services are not eligible for Traffic Mirror. Use
    /// <c>AddNetworkServices</c> to add network services to a Traffic Mirror filter. When
    /// a network service is added to the Traffic Mirror filter, all traffic related to that
    /// network service will be mirrored. When you no longer want to mirror network services,
    /// use <c>RemoveNetworkServices</c> to remove the network services from the Traffic Mirror
    /// filter. 
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2TrafficMirrorFilterNetworkService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TrafficMirrorFilter")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyTrafficMirrorFilterNetworkServices API operation.", Operation = new[] {"ModifyTrafficMirrorFilterNetworkServices"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyTrafficMirrorFilterNetworkServicesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TrafficMirrorFilter or Amazon.EC2.Model.ModifyTrafficMirrorFilterNetworkServicesResponse",
        "This cmdlet returns an Amazon.EC2.Model.TrafficMirrorFilter object.",
        "The service call response (type Amazon.EC2.Model.ModifyTrafficMirrorFilterNetworkServicesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2TrafficMirrorFilterNetworkServiceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AddNetworkService
        /// <summary>
        /// <para>
        /// <para>The network service, for example Amazon DNS, that you want to mirror.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddNetworkServices")]
        public System.String[] AddNetworkService { get; set; }
        #endregion
        
        #region Parameter RemoveNetworkService
        /// <summary>
        /// <para>
        /// <para>The network service, for example Amazon DNS, that you no longer want to mirror.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveNetworkServices")]
        public System.String[] RemoveNetworkService { get; set; }
        #endregion
        
        #region Parameter TrafficMirrorFilterId
        /// <summary>
        /// <para>
        /// <para>The ID of the Traffic Mirror filter.</para>
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
        public System.String TrafficMirrorFilterId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrafficMirrorFilter'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyTrafficMirrorFilterNetworkServicesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyTrafficMirrorFilterNetworkServicesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrafficMirrorFilter";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrafficMirrorFilterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2TrafficMirrorFilterNetworkService (ModifyTrafficMirrorFilterNetworkServices)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyTrafficMirrorFilterNetworkServicesResponse, EditEC2TrafficMirrorFilterNetworkServiceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AddNetworkService != null)
            {
                context.AddNetworkService = new List<System.String>(this.AddNetworkService);
            }
            if (this.RemoveNetworkService != null)
            {
                context.RemoveNetworkService = new List<System.String>(this.RemoveNetworkService);
            }
            context.TrafficMirrorFilterId = this.TrafficMirrorFilterId;
            #if MODULAR
            if (this.TrafficMirrorFilterId == null && ParameterWasBound(nameof(this.TrafficMirrorFilterId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficMirrorFilterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyTrafficMirrorFilterNetworkServicesRequest();
            
            if (cmdletContext.AddNetworkService != null)
            {
                request.AddNetworkServices = cmdletContext.AddNetworkService;
            }
            if (cmdletContext.RemoveNetworkService != null)
            {
                request.RemoveNetworkServices = cmdletContext.RemoveNetworkService;
            }
            if (cmdletContext.TrafficMirrorFilterId != null)
            {
                request.TrafficMirrorFilterId = cmdletContext.TrafficMirrorFilterId;
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
        
        private Amazon.EC2.Model.ModifyTrafficMirrorFilterNetworkServicesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyTrafficMirrorFilterNetworkServicesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyTrafficMirrorFilterNetworkServices");
            try
            {
                #if DESKTOP
                return client.ModifyTrafficMirrorFilterNetworkServices(request);
                #elif CORECLR
                return client.ModifyTrafficMirrorFilterNetworkServicesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AddNetworkService { get; set; }
            public List<System.String> RemoveNetworkService { get; set; }
            public System.String TrafficMirrorFilterId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyTrafficMirrorFilterNetworkServicesResponse, EditEC2TrafficMirrorFilterNetworkServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrafficMirrorFilter;
        }
        
    }
}
